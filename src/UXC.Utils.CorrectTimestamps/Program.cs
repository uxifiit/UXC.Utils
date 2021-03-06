using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using UXI.Filters;
using UXC.Utils.CorrectTimestamps.Configuration;

namespace UXC.Utils.CorrectTimestamps
{
    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<CorrectTimestampsOptions>
            (
                // filter:
                new RelayFilter<DoublyTimestampedDataPayload, DoublyTimestampedDataPayload, CorrectTimestampsOptions>(CorrectTimestamps),

                // configurations:
                new DoublyTimestampedDataPayloadSerializationConfiguration(),
                new TimestampsDiffStatisticsObserverConfiguration()
            ).Execute(args);
        }


        private static IObservable<DoublyTimestampedDataPayload> CorrectTimestamps(IObservable<DoublyTimestampedDataPayload> timestamps, CorrectTimestampsOptions options, FilterContext context)
        {
            return Observable.Create<DoublyTimestampedDataPayload>(observer =>
            {
                var source = timestamps.ToEnumerable();
                var result = TimestampCorrection.Correct(source);

                return result.ToObservable()
                             .Publish().RefCount()
                             .Subscribe(observer);
            });
        }
    }
}
