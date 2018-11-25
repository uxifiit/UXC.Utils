using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeDataTimestampCorrection
{
    class GazeDataTimestamp
    {
        public GazeDataTimestamp(JObject payload, long originalTicks, long referenceTicks, TimeSpan offset)
        {
            Payload = payload;
            OriginalTicks = originalTicks;
            ReferenceTicks = referenceTicks;
            Offset = offset;
        }

        public long OriginalTicks { get; }
        public long ReferenceTicks { get; }
        public long NewTicks { get; set; }
        public TimeSpan Offset { get; }
        public JObject Payload { get; }
    }
}
