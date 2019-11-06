using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Selector
{
    class TimestampedDataPayload : ITimestampedData
    {
        public TimestampedDataPayload(JObject payload, DateTimeOffset timestamp)
        {
            Payload = payload;
            Timestamp = timestamp;
        }

        public JObject Payload { get; }

        public DateTimeOffset Timestamp { get; }
    }
}
