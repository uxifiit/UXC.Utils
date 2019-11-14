using System;
using UXC.Utils.MapToOgama.Data;

namespace UXC.Utils.MapToOgama.Ogama.Events
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

            if (state.TrialImage != _event.Step.Tag)
            {
                state.TrialImage = _event.Step.Tag;
                state.TrialSequence++;
                state.TrialID++;
            }
        }
    }
}