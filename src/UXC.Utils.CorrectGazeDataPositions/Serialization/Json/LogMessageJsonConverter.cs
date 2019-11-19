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
    class LogMessageJsonConverter : GenericJsonConverter<LogMessage>
    {
        protected override LogMessage Convert(JToken token, JsonSerializer serializer)
        {
            JObject obj = (JObject)token;

            var timestamp = obj.GetValue<DateTimeOffset>(nameof(LogMessage.Timestamp), serializer);
            var message = obj.GetValue<string>(nameof(LogMessage.Message), serializer);

            return new LogMessage(timestamp, message);
        }
    }
}
