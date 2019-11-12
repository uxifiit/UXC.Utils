using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Core.Data;
using UXC.Utils.MapToOgama.Configuration;
using UXC.Utils.MapToOgama.Options;
using UXI.Filters;
using UXI.Filters.Common.Extensions;
using UXI.Filters.Configuration;

namespace UXC.Utils.MapToOgama
{
    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<MapToOgamaContext>
            (
                new RelayFilter<GazeData, OgamaData, MapToOgamaOptions, MapToOgamaContext>("Map to Ogama Data", MapToOgama),
                new UXCDataSerializationFilterConfiguration(),
                new AdditionalInputsFilterConfiguration()
            ).Execute(args);
        }

        private static IObservable<OgamaData> MapToOgama(IObservable<GazeData> gaze, MapToOgamaOptions options, MapToOgamaContext context)
        {
            var mouse = context.IO.ReadInput(context.InputMouseData, null);
            var session = context.IO.ReadInput(context.InputSessionEvents, null);

            // merge gaze, mouse, session and produce OgamaData


            
        }
    }
}
