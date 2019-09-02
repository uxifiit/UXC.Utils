using CommandLine.Text;
using TimestampCorrection.Serialization.Csv.Converters;
using TimestampCorrection.Serialization.Json.Converters;
using TimestampCorrection.Statistics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Serialization.Csv;
using UXI.Serialization.Json;
using UXI.Filters;
using UXI.Serialization.Extensions;
using UXI.Filters.Common.Extensions;
using UXI.Filters.Serialization.Converters;
using UXI.Serialization.Json.Configurations;
using UXI.Serialization.Csv.Configurations;
using TimestampCorrection.Configuration;

namespace TimestampCorrection
{
    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<TimestampCorrectionOptions>
            (
                // filter:
                new RelayFilter<DoublyTimestampedDataPayload, DoublyTimestampedDataPayload, TimestampCorrectionOptions>(CorrectTimestamps),

                // configurations:
                new DoublyTimestampedDataPayloadSerializationConfiguration(),
                new TimestampsDiffStatisticsObserverConfiguration()
            ).Execute(args);
        }


        private static IObservable<DoublyTimestampedDataPayload> CorrectTimestamps(IObservable<DoublyTimestampedDataPayload> timestamps, Options options, FilterContext context)
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
