using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UXC.Utils.CorrectGazeDataPositions.Data;
using UXI.Serialization.Formats.Json.Extensions;
using UXI.Serialization.Formats.Json.Converters;

namespace UXC.Utils.CorrectGazeDataPositions.Serialization.Json
{
    class DisplayAreaChangedLogMessageJsonConverter : GenericJsonConverter<DisplayAreaChangedLogMessage>
    {
        protected override DisplayAreaChangedLogMessage Convert(JToken token, JsonSerializer serializer)
        {
            JObject obj = (JObject)token;

            var logMessage = obj.ToObject<LogMessage>(serializer);

            if (logMessage.Message.IndexOf("display", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                var displayArea = obj.GetValue<DisplayArea>(nameof(DisplayAreaChangedLogMessage.Content), serializer);

                return new DisplayAreaChangedLogMessage(logMessage, displayArea);
            }

            return null;
        }
    }
}
