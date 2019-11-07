using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UXI.Filters.Serialization.Converters;
using UXI.Serialization.Formats.Json.Converters;

namespace UXC.Utils.Select.Serialization.Json.Converters
{
    class TimestampedDataPayloadJsonConverter : GenericJsonConverter<TimestampedDataPayload>
    {
        private readonly string _timestampField;

        public TimestampedDataPayloadJsonConverter(string timestampField)
        {
            _timestampField = timestampField;
        }


        public override bool CanRead => true;


        public override bool CanWrite => true;


        protected override TimestampedDataPayload Convert(JToken token, JsonSerializer serializer)
        {
            JObject obj = (JObject)token;

            var timestamp = obj[_timestampField].ToObject<DateTimeOffset>(serializer);

            return new TimestampedDataPayload(obj, timestamp);
        }


        protected override JToken ConvertBack(TimestampedDataPayload value, JsonSerializer serializer)
        {
            JObject obj = value.Payload;

            obj[_timestampField] = JRaw.FromObject(value.Timestamp, serializer);

            return obj;
        }
    }
}
