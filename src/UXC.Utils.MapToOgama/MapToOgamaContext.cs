using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters;
using UXI.GazeToolkit;

namespace UXC.Utils.MapToOgama
{
    class MapToOgamaContext : FilterContext
    {
        public InputDescriptor InputMouseData { get; set; }
        public InputDescriptor InputSessionEvents { get; set; }

        public Point2 ScreenResolution { get; set; }
    }
}
