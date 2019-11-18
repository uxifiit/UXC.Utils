using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UXC.Utils.MapToOgama.Data;
using UXC.Utils.MapToOgama.Data.UXC;
using UXI.Serialization.Formats.Json.Converters;
using UXI.Serialization.Formats.Json.Extensions;

namespace UXC.Utils.MapToOgama.Serialization.Json
{
    class SessionStepActionJsonConverter : GenericJsonConverter<SessionStepAction>
    {
        protected override SessionStepAction Convert(JToken token, JsonSerializer serializer)
        {
            JObject obj = (JObject)token;
            JObject action = obj.GetValue<JObject>("Action", serializer);

            string actionType = action.GetValue<string>(nameof(SessionStepAction.ActionType), serializer);
            string tag = action.GetValue<string>(nameof(SessionStepAction.Tag), serializer);

            return new SessionStepAction(actionType, tag);
        }
    }
}
