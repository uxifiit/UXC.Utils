using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.GazeToolkit;

namespace TimestampCorrection
{
    public class DoublyTimestampedData : ITimestampedData
    {
        public DoublyTimestampedData(JObject payload, DateTimeOffset timestamp, DateTimeOffset referenceTimestamp)
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
