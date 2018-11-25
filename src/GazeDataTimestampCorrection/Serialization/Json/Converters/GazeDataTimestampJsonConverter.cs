using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UXI.GazeToolkit.Serialization.Json.Converters;

namespace GazeDataTimestampCorrection.Serialization.Json.Converters
{
    class GazeDataTimestampJsonConverter : UXI.GazeToolkit.Serialization.Json.Converters.JsonConverter<GazeDataTimestamp>
    {
        private static readonly long EpochTicks = DateTimeOffset.FromUnixTimeSeconds(0).Ticks;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        protected override GazeDataTimestamp Convert(JToken token, JsonSerializer serializer)
        {
            JObject obj = (JObject)token;

            long trackerTicks = obj["TrackerTicks"].ToObject<long>();
            trackerTicks *= 10;

            var timestamp = obj["Timestamp"].ToObject<DateTimeOffset>(serializer);
            long timestampUnixTicks = timestamp.Ticks - EpochTicks;

            //if (timestampUnixTicks < minTicks) { minTicks = timestampUnixTicks; }
            //if (timestampUnixTicks > maxTicks) { maxTicks = timestampUnixTicks; }

            return new GazeDataTimestamp(obj, timestampUnixTicks, trackerTicks, timestamp.Offset);
        }


        protected override JToken ConvertBack(GazeDataTimestamp value, JsonSerializer serializer)
        {
            JObject obj = value.Payload;

            var newTimestamp = new DateTimeOffset(EpochTicks + value.NewTicks, value.Offset);

            obj["Timestamp"] = JRaw.FromObject(newTimestamp, serializer);

            return obj;
        }
    }
}
