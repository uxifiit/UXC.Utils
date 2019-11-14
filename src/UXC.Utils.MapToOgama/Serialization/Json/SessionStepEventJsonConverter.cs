using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UXC.Utils.MapToOgama.Data;
using UXI.Serialization.Formats.Json.Converters;
using UXI.Serialization.Formats.Json.Extensions;

namespace UXC.Utils.MapToOgama.Serialization.Json
{
    class SessionStepEventJsonConverter : GenericJsonConverter<SessionStepEvent>
    {
        protected override SessionStepEvent Convert(JToken token, JsonSerializer serializer)
        {
            JObject obj = (JObject)token;

            DateTime timestamp = obj.GetValue<DateTime>(nameof(SessionStepEvent.Timestamp), serializer);
            string eventType = obj.GetValue<string>(nameof(SessionStepEvent.EventType), serializer);
            string state = obj.GetValue<string>(nameof(SessionStepEvent.State), serializer);
            SessionStepAction step = obj.GetValue<SessionStepAction>(nameof(SessionStepEvent.Step), serializer);

            return new SessionStepEvent(timestamp, state, eventType, step);
        }
    }
}
