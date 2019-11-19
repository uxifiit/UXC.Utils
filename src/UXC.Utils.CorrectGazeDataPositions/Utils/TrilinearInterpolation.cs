using UXI.GazeToolkit;

namespace UXC.Utils.CorrectGazeDataPositions.Utils
{
    public class TrilinearInterpolation
    {
        private readonly Point3 _a;
        private readonly Point3 _b;
        private readonly Point3 _c;
        private readonly Point3 _d;
        private readonly Point3 _e;
        private readonly Point3 _f;
        private readonly Point3 _g;
        private readonly Point3 _h;

       
        public TrilinearInterpolation(Hexahedron hexahedron)
        {
            Hexahedron = hexahedron;

            // label
            var x0 = hexahedron.Vertex000;
            var x1 = hexahedron.Vertex100;
            var x2 = hexahedron.Vertex110;
            var x3 = hexahedron.Vertex010;
            var x4 = hexahedron.Vertex011;
            var x5 = hexahedron.Vertex111;
            var x6 = hexahedron.Vertex101;
            var x7 = hexahedron.Vertex001;

            // parameters
            _a = x0;
            _b = x1 - x0;
            _c = x3 - x0;
            _d = x7 - x0;
            _e = x2 - x1 - x3 + x0;
            _f = x4 - x3 - x7 + x0;
            _g = x6 - x1 - x7 + x0;
            _h = x5 + x1 + x3 + x7 - x6 - x4 - x2 - x0;
        }


        public Hexahedron Hexahedron { get; }


        public Point3 Convert(Point3 point)
        {
            return _a
                 + _b * point.X
                 + _c * point.Y
                 + _d * point.Z
                 + _e * point.X * point.Y
                 + _f * point.Y * point.Z
                 + _g * point.X * point.Z
                 + _h * point.X * point.Y * point.Z;
        }
    }
}

