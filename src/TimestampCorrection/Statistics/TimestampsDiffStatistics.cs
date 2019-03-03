using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using UXI.GazeFilter.Statistics;
using UXI.GazeToolkit;
using UXI.GazeToolkit.Serialization;
using UXI.Serialization;

namespace TimestampCorrection.Statistics
{
    class TimestampsDiffStatistics : IFilterStatistics
    {
        private readonly TimestampedDataCounter _inputCounter = new TimestampedDataCounter();
        private readonly TimestampedDataCounter _outputCounter = new TimestampedDataCounter();

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


        private class TimestampedDataCounter : IObserver<object>
        {
            public int Count { get; private set; }

            public long MinTicks { get; private set; } = Int64.MaxValue;

            public long MaxTicks { get; private set; } = Int64.MinValue;

            public long Duration => Count > 0 ? MaxTicks - MinTicks : 0L;

            public void OnNext(object value)
            {
                if (value is ITimestampedData)
                {
                    var data = (ITimestampedData)value;
                    Count += 1;

                    long ticks = data.Timestamp.Ticks;

                    if (ticks < MinTicks)
                    {
                        MinTicks = ticks;
                    }

                    if (ticks > MaxTicks)
                    {
                        MaxTicks = ticks;
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
