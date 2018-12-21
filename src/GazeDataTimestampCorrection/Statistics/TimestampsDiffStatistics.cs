using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using UXI.GazeFilter.Statistics;
using UXI.GazeToolkit.Serialization;
using UXI.Serialization;

namespace GazeDataTimestampCorrection.Statistics
{
    class TimestampsDiffStatistics : IFilterStatistics
    {
        private readonly GazeDataTimestampCounter _inputCounter = new GazeDataTimestampCounter();
        private readonly GazeDataTimestampCounter _outputCounter = new GazeDataTimestampCounter();

        public Type DataType { get; } = typeof(TimestampsDiff);

        public FileFormat DefaultFormat => FileFormat.CSV;

        public IObserver<object> InputObserver => _inputCounter;

        public IObserver<object> OutputObserver => _outputCounter;

        public IEnumerable<object> GetResults()
        {
            yield return new TimestampsDiff
            (
                _outputCounter.Count,
                _inputCounter.Duration,
                _outputCounter.Duration,
                _outputCounter.MinTicks - _inputCounter.MinTicks,
                _outputCounter.MaxTicks - _inputCounter.MaxTicks,
                _outputCounter.Duration - _inputCounter.Duration
            );
        }


        private class GazeDataTimestampCounter : IObserver<object>
        {
            public int Count { get; private set; }

            public long MinTicks { get; private set; } = Int64.MaxValue;
            public long MaxTicks { get; private set; } = Int64.MinValue;

            public long Duration => Count > 0 ? MaxTicks - MinTicks : 0;

            public void OnNext(object value)
            {
                if (value is GazeDataTimestamp)
                {
                    var data = (GazeDataTimestamp)value;
                    Count += 1;

                    if (data.Ticks < MinTicks)
                    {
                        MinTicks = data.Ticks;
                    }

                    if (data.Ticks > MaxTicks)
                    {
                        MaxTicks = data.Ticks;
                    }
                }
            }

            public void OnCompleted()
            {
            }

            public void OnError(Exception error)
            {
            }
        }
    }
}
