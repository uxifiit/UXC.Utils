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

namespace UXC.Utils.CorrectTimestamps.Serialization.Json.Converters
{
    class DoublyTimestampedDataPayloadJsonConverter : GenericJsonConverter<DoublyTimestampedDataPayload>
    {
        private readonly string _timestampField;
        private readonly string _referenceTimestampField;
        private readonly ITimestampStringConverter _referenceTimestampConverter;

        public DoublyTimestampedDataPayloadJsonConverter(string timestampField, string referenceTimestampField, ITimestampStringConverter referenceTimestampConverter)
        {
            _timestampField = timestampField;
            _referenceTimestampField = referenceTimestampField;
            _referenceTimestampConverter = referenceTimestampConverter;
        }


        public override bool CanRead => true;


        public override bool CanWrite => true;


        protected override DoublyTimestampedDataPayload Convert(JToken token, JsonSerializer serializer)
        {
            JObject obj = (JObject)token;

            string referenceTimestampFieldValue = obj[_referenceTimestampField].ToObject<string>();
            DateTimeOffset referenceTimestamp = _referenceTimestampConverter.Convert(referenceTimestampFieldValue);

            var timestamp = obj[_timestampField].ToObject<DateTimeOffset>(serializer);

            return new DoublyTimestampedDataPayload(obj, timestamp, referenceTimestamp);
        }


        protected override JToken ConvertBack(DoublyTimestampedDataPayload value, JsonSerializer serializer)
        {
            JObject obj = value.Payload;

            obj[_timestampField] = JRaw.FromObject(value.Timestamp, serializer);

            return obj;
        }
    }
}
