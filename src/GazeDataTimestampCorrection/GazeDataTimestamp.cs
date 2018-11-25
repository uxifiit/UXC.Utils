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
        public GazeDataTimestamp(JObject payload, long ticks, long referenceTicks, TimeSpan offset)
        {
            Payload = payload;
            Ticks = ticks;
            ReferenceTicks = referenceTicks;
            Offset = offset;
        }

        public long Ticks { get; }
        public long ReferenceTicks { get; }
        public TimeSpan Offset { get; }
        public JObject Payload { get; }
    }
}
