using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Core.Data;

namespace UXC.Utils.CorrectGazeDataPositions.Data
{
    public class TrackBoxCoords
    {
        public Point3 FrontUpperRight { get; set; }
        public Point3 FrontUpperLeft { get; set; }
        public Point3 FrontLowerLeft { get; set; }
        public Point3 FrontLowerRight { get; set; }
        public Point3 BackUpperRight { get; set; }
        public Point3 BackUpperLeft { get; set; }
        public Point3 BackLowerLeft { get; set; }
        public Point3 BackLowerRight { get; set; }
    }

}
