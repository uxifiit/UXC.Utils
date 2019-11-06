using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimestampCorrection
{
    public class DoublyTimestampedDataPayload : ITimestampedData
    {
        public DoublyTimestampedDataPayload(JObject payload, DateTimeOffset timestamp, DateTimeOffset referenceTimestamp)
        {
            Payload = payload;
            Timestamp = timestamp;
            ReferenceTimestamp = referenceTimestamp;
        }

        public JObject Payload { get; }

        public DateTimeOffset Timestamp { get; }

        public DateTimeOffset ReferenceTimestamp { get; }
    }
}
