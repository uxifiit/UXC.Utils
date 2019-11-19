using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UXC.Utils.CorrectGazeDataPositions.Data;
using UXI.Serialization.Formats.Json.Converters;
using UXI.Serialization.Formats.Json.Extensions;

namespace UXC.Utils.CorrectGazeDataPositions.Serialization.Json
{
    class TrackBoxChangedLogMessageJsonConverter : GenericJsonConverter<TrackBoxChangedLogMessage>
    {
        protected override TrackBoxChangedLogMessage Convert(JToken token, JsonSerializer serializer)
        {
            JObject obj = (JObject)token;

            var logMessage = obj.ToObject<LogMessage>(serializer);

            if (logMessage.Message.IndexOf("trackbox", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                var trackbox = obj.GetValue<TrackBoxCoords>(nameof(TrackBoxChangedLogMessage.Content), serializer);

                return new TrackBoxChangedLogMessage(logMessage, trackbox);
            }

            return null;
        }
    }
}
