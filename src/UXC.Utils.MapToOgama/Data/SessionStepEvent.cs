using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UXC.Utils.MapToOgama.Data.UXC
{
    public class SessionStepEvent
    {
        public SessionStepEvent(DateTime timestamp, string state, string eventType, SessionStepAction step)
        {
            Timestamp = timestamp;
            State = state;
            EventType = eventType;
            Step = step;
        }

        public string State { get; set; }

        public string EventType { get; set; }

        public DateTime Timestamp { get; set; }

        public SessionStepAction Step { get; set; }
    }



    public class SessionStepAction
    {
        public SessionStepAction(string actionType, string tag)
        {
            ActionType = actionType;
            Tag = tag;
        }

        public string ActionType { get; set; }

        public string Tag { get; set; }
    }
}
