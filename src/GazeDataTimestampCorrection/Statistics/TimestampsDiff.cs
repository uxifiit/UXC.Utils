using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeDataTimestampCorrection.Statistics
{
    class TimestampsDiff
    {
        public TimestampsDiff(int count, long duration, long newDuration, long startOffset, long endOffset, long durationChange)
        {
            Count = count;
            Duration = duration;
            NewDuration = newDuration;
            StartOffset = startOffset;
            EndOffset = endOffset;
            DurationChange = durationChange;
        }

        public int Count { get; }
        public long Duration { get; }
        public long NewDuration { get; }
        public long StartOffset { get; }
        public long EndOffset { get; }
        public long DurationChange { get; }
    }
}
