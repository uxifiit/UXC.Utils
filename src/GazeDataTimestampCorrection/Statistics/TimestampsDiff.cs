using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeDataTimestampCorrection.Statistics
{
    class TimestampsDiff
    {
        public TimestampsDiff(int count, double duration, double newDuration, double startOffset, double endOffset, double durationChange)
        {
            Count = count;
            Duration = duration;
            NewDuration = newDuration;
            StartOffset = startOffset;
            EndOffset = endOffset;
            DurationChange = durationChange;
        }

        public int Count { get; }
        public double Duration { get; }
        public double NewDuration { get; }
        public double StartOffset { get; }
        public double EndOffset { get; }
        public double DurationChange { get; }
    }
}
