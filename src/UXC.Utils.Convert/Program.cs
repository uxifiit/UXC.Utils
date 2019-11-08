using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Core.Data;
using UXC.Utils.Convert.Configuration;
using UXI.Filters;
using UXI.Filters.Configuration;

namespace UXC.Utils.Convert
{
    class Program
    {
        static int Main(string[] args)
        {
            return new MultiFilterHost
            (
                new FilterConfiguration[]
                {
                    new UXCDataSerializationFilterConfiguration(),
                    new PrettyFormatFilterConfiguration()
                },
                new RelayFilter<GazeData, GazeData, ConvertGazeDataOptions>("Convert Gaze Data", (s, _, __) => s),
                new RelayFilter<ExternalEventData, ExternalEventData, ConvertExternalEventDataOptions>("Convert External Events", (s, _, __) => s),
                new RelayFilter<KeyboardEventData, KeyboardEventData, ConvertKeyboardEventDataOptions>("Convert Keyboard Events", (s, _, __) => s),
                new RelayFilter<MouseEventData, MouseEventData, ConvertMouseEventDataOptions>("Convert Mouse Events", (s, _, __) => s)
            ).Execute(args);
        }
    }
}
