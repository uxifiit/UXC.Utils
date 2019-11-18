using System;
using UXC.Utils.MapToOgama.Data;
using UXC.Utils.MapToOgama.Data.UXC;

namespace UXC.Utils.MapToOgama.Data.Ogama.Events
{
    public class OgamaSessionStepEvent : OgamaEvent
    {
        private readonly SessionStepEvent _event;

        public OgamaSessionStepEvent(SessionStepEvent @event)
        {
            _event = @event;
        }

        public override DateTimeOffset Timestamp => _event.Timestamp;

        public override void Apply(OgamaModel.State state)
        {
            base.Apply(state);

            if (_event.Step != null && state.TrialImage != _event.Step.Tag)
            {
                state.TrialImage = _event.Step.Tag;
                state.TrialSequence++;
                state.TrialID++;
            }
        }
    }
}