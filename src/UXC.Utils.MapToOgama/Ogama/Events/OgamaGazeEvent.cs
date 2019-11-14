using System;
using UXI.GazeToolkit;

namespace UXC.Utils.MapToOgama.Ogama.Events
{
    public class OgamaGazeEvent : OgamaEvent
    {
        private readonly SingleEyeGazeData _gaze;
        private readonly double _resolutionWidth;
        private readonly double _resolutionHeight;

        public OgamaGazeEvent(SingleEyeGazeData gaze, double resolutionWidth, double resolutionHeight)
        {
            _gaze = gaze;
            _resolutionWidth = resolutionWidth;
            _resolutionHeight = resolutionHeight;
        }

        public override DateTimeOffset Timestamp => _gaze.Timestamp;

        public override void Apply(OgamaModel.State state)
        {
            base.Apply(state);

            state.GazePos = new Point2(_gaze.GazePoint2D.X * _resolutionWidth, _gaze.GazePoint2D.Y * _resolutionHeight);
            state.PupilDia = new Point2(_gaze.PupilDiameter, _gaze.PupilDiameter);
        }
    }
}