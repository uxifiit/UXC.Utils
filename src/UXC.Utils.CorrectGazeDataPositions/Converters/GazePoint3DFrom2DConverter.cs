using UXC.Utils.CorrectGazeDataPositions.Data;
using UXI.GazeToolkit;

namespace UXC.Utils.CorrectGazeDataPositions
{
    public class GazePoint3DFrom2DConverter
    {
        public DisplayArea _displayArea;

        public GazePoint3DFrom2DConverter(DisplayArea displayArea)
        {
            _displayArea = displayArea;
        }

        public Point3 Convert(Point2 gazePoint2D)
        {
            var dx = (_displayArea.TopRight - _displayArea.TopLeft) * gazePoint2D.X;
            var dy = (_displayArea.BottomLeft - _displayArea.TopLeft) * gazePoint2D.Y;
            return _displayArea.TopLeft + (dx + dy);
        }
    }
}

