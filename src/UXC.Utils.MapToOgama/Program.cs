using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Core.Data;
using UXC.Core.Data.Compatibility.GazeToolkit;
using UXC.Utils.MapToOgama.Configuration;
using UXC.Utils.MapToOgama.Data.Ogama;
using UXC.Utils.MapToOgama.Data.Ogama.Events;
using UXC.Utils.MapToOgama.Data.UXC;
using UXC.Utils.MapToOgama.Options;
using UXI.Filters;
using UXI.Filters.Common.Extensions;
using UXI.Filters.Configuration;
using UXI.GazeToolkit.Selection;

namespace UXC.Utils.MapToOgama
{
    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<MapToOgamaContext, MapToOgamaOptions>
            (
                new RelayFilter<GazeData, OgamaData, MapToOgamaOptions, MapToOgamaContext>("Map to Ogama Data", MapToOgama),
                new UXCDataSerializationFilterConfiguration(),
                new ScreenResolutionFilterConfiguration(),
                new AdditionalInputsFilterConfiguration(),
                new OgamaDataSerializationFilterConfiguration()
            ).Execute(args);
        }

        private static IObservable<OgamaData> MapToOgama(IObservable<GazeData> gaze, MapToOgamaOptions options, MapToOgamaContext context)
        {
            return Observable.Create<OgamaData>(observer =>
            {
                var model = new OgamaModel(options.SubjectName);

                var mouse = context.IO.ReadInput<MouseEventData>(context.InputMouseData, null)
                                   .Select(ev => new OgamaMouseEvent(ev, context.ScreenResolution.X, context.ScreenResolution.Y));
                var session = context.IO.ReadInput<SessionStepEvent>(context.InputSessionEvents, null)
                                     .Select(ev => new OgamaSessionStepEvent(ev));

                var mergedEnum = mouse.Merge<OgamaEvent>(session).GetEnumerator();

                bool hasNextOtherEvent = mergedEnum.MoveNext();

                bool isFirst = true;
                DateTimeOffset referenceTimestamp = DateTimeOffset.MinValue;

                return gaze.Select(g => g.ToToolkit())
                           .SelectEye(options.EyeSelectionStrategy)
                           .Select(eye => new OgamaGazeEvent(eye, context.ScreenResolution.X, context.ScreenResolution.Y))
                           .Subscribe(gazeEvent =>
                           {
                               while (hasNextOtherEvent && mergedEnum.Current.CompareTo(gazeEvent) <= 0)
                               {
                                   model.ReceiveEvent(mergedEnum.Current);

                                   hasNextOtherEvent = mergedEnum.MoveNext();
                               }

                               model.ReceiveEvent(gazeEvent);

                               if (isFirst)
                               {
                                   referenceTimestamp = gazeEvent.Timestamp;
                                   isFirst = false;
                               }
                               else
                               {
                                   observer.OnNext(model.GenerateData(referenceTimestamp));
                               }
                           }, ex => observer.OnError(ex), () => observer.OnCompleted());
            });
        }
    }
}
