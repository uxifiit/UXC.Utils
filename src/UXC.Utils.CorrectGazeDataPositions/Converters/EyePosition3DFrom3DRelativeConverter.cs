using UXC.Utils.CorrectGazeDataPositions.Data;
using UXC.Utils.CorrectGazeDataPositions.Utils;
using UXI.GazeToolkit;

namespace UXC.Utils.CorrectGazeDataPositions
{
    public class EyePosition3DFrom3DRelativeConverter
    {
        private readonly TrilinearInterpolation _interpolation;

        public EyePosition3DFrom3DRelativeConverter(TrackBoxCoords trackbox)
        {
            var hexahedron = new Hexahedron
                (
                    vertex000: trackbox.BackLowerRight,
                    vertex100: trackbox.BackLowerLeft,
                    vertex110: trackbox.BackUpperRight,
                    vertex010: trackbox.BackUpperLeft,

                    vertex001: trackbox.FrontLowerRight,
                    vertex101: trackbox.FrontLowerLeft,
                    vertex111: trackbox.FrontUpperRight,
                    vertex011: trackbox.FrontUpperLeft
                );

            _interpolation = new TrilinearInterpolation(hexahedron);
        }

        public Point3 Convert(Point3 relativePosition3D)
        {
            return _interpolation.Convert(relativePosition3D);
        }
    }
}

