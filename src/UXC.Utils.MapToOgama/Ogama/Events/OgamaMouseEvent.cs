using System;
using UXI.GazeToolkit;

namespace UXC.Utils.MapToOgama.Ogama.Events
{
    public class OgamaMouseEvent : OgamaEvent
    {
        private readonly Core.Data.MouseEventData _mouse;
        private readonly double _resolutionWidth;
        private readonly double _resolutionHeight;

        public OgamaMouseEvent(Core.Data.MouseEventData mouse, double resolutionWidth, double resolutionHeight)
        {
            _mouse = mouse;
            _resolutionWidth = resolutionWidth;
            _resolutionHeight = resolutionHeight;
        }

        public override DateTimeOffset Timestamp => _mouse.Timestamp;

        public override void Apply(OgamaModel.State state)
        {
            base.Apply(state);

            state.MousePos = new Point2(_mouse.X, _mouse.Y);
        }
    }
}