using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters;

namespace UXC.Utils.CorrectGazeDataPositions
{
    class CorrectGazeDataPositionsContext : FilterContext
    {
        public InputDescriptor InputTrackBoxChanges { get; set; }

        public InputDescriptor InputDisplayAreaChanges { get; set; }
    }
}
