using GazeDataTimestampCorrection.Serialization.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.GazeFilter;
using UXI.GazeToolkit.Serialization;
using UXI.GazeToolkit.Serialization.Json;

namespace GazeDataTimestampCorrection
{
    class Options : BaseOptions { }

    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<Options>
            (
                context => Configure(context),
                new RelayFilter<GazeDataTimestamp, GazeDataTimestamp, Options>(CorrectTimestamps)
            ).Execute(args);
        }


        private static void Configure(FilterContext context)
        {
            context.Formats = new Collection<IDataSerializationFactory>()
            {
                new JsonSerializationFactory(new GazeDataTimestampJsonConverter())
            };
        }


        private static IObservable<GazeDataTimestamp> CorrectTimestamps(IObservable<GazeDataTimestamp> timestamps, Options options)
        {
            return Observable.Create<GazeDataTimestamp>(observer =>
            {
                List<GazeDataTimestamp> data = new List<GazeDataTimestamp>();

                timestamps.Do(d => data.Add(d)).Wait();

                long minTicksDiff = data.Min(d => d.OriginalTicks - d.ReferenceTicks);

                List<GazeDataTimestamp> newData = data.OrderBy(d => d.ReferenceTicks).ToList();

                foreach (var item in newData)
                {
                    item.NewTicks = item.ReferenceTicks + minTicksDiff;
                }

                return data.ToObservable()
                           .Publish().RefCount()
                           .Subscribe(observer);
            });
        }
    }
}
