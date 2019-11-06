using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters;
using UXI.Filters.Observers;
using UXI.Serialization;

namespace TimestampCorrection.Statistics
{
    class TimestampsDiffStatisticsObserver : IFilterObserver
    {
        public TimestampsDiffStatisticsObserver(OutputDescriptor output)
        {
            Output = output;

            Results = Observable.Create<object>((observer) =>
            {
                var inputs = new TimestampedDataCounter();
                var outputs = new TimestampedDataCounter();

                InputObserver = System.Reactive.Observer.Create<object>(v => inputs.Add(v));
                OutputObserver = System.Reactive.Observer.Create<object>(v => outputs.Add(v), ex => observer.OnError(ex), () => Complete(inputs, outputs, observer));

                return Disposable.Empty;
            }).Publish().RefCount();
        }


        public IObserver<object> InputObserver { get; private set; }


        public IObserver<object> OutputObserver { get; private set; }


        public IObservable<object> Results { get; }


        public OutputDescriptor Output { get; }


        private void Complete(TimestampedDataCounter inputs, TimestampedDataCounter outputs, IObserver<object> observer)
        {
            var result = new TimestampsDiff
            (
                outputs.Count,
                inputs.Duration,
                outputs.Duration,
                outputs.MinTicks - inputs.MinTicks,
                outputs.MaxTicks - inputs.MaxTicks,
                outputs.Duration - inputs.Duration
            );

            observer.OnNext(result);

            observer.OnCompleted();
        }


        private class TimestampedDataCounter
        {
            public int Count { get; private set; }

            public long MinTicks { get; private set; } = Int64.MaxValue;

            public long MaxTicks { get; private set; } = Int64.MinValue;

            public long Duration => Count > 0 ? MaxTicks - MinTicks : 0L;

            public void Add(object value)
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
        }
    }
}
