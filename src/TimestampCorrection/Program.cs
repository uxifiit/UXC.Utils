using CommandLine;
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
using UXI.GazeFilter;
using UXI.GazeFilter.Statistics;
using UXI.GazeToolkit.Serialization;
using UXI.GazeToolkit.Serialization.Converters;
using UXI.GazeToolkit.Serialization.Csv;
using UXI.GazeToolkit.Serialization.Json;
using UXI.GazeToolkit.Serialization.Json.Converters;
using UXI.Serialization;
using UXI.Serialization.Csv;
using UXI.Serialization.Json;

namespace TimestampCorrection
{
    class Options : BaseOptions
    {
        [Option("reference-timestamp-field", HelpText = "Name of the reference timestamp field in the data, for example 'Timestamp'.", Required = true)]
        public string ReferenceTimestampFieldName { get; set; }

        [Option("reference-timestamp-format", HelpText = "Format of reference timestamps in data.", Required = true)]
        public string ReferenceTimestampFormat { get; set; }
    }


    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<Options>
            (
                (context, options) => Configure(context, (Options)options),
                new RelayFilter<DoublyTimestampedData, DoublyTimestampedData, Options>(CorrectTimestamps)
            ).Execute(args);
        }


        private static void Configure(FilterContext context, Options options)
        {
            var referenceTimestampConverter = TimestampStringConverterResolver.Default.Resolve(options.ReferenceTimestampFormat);

            var dataConverter = new DoublyTimestampedDataJsonConverter
                                (
                                    options.TimestampFieldName,
                                    options.ReferenceTimestampFieldName,
                                    referenceTimestampConverter
                                );

            context.Formats
                   .FirstOrDefault(f => f.Format == FileFormat.JSON)?
                   .Configurations
                   .Add(new JsonConvertersSerializationConfiguration(dataConverter));

            context.Formats
                   .FirstOrDefault(f => f.Format == FileFormat.CSV)?
                   .Configurations
                   .Add(new CsvConvertersSerializationConfiguration(new TimestampsDiffCsvConverter()));

            // force use of a Timestamp converter
            context.Serialization.TimestampConverter = context.Serialization.TimestampConverter 
                                                    ?? new TimestampFromDateTimeConverter();

            context.Statistics = new Collection<IFilterStatisticsFactory>()
            {
                new TimestampsDiffStatisticsFactory()
            };
        }


        private static IObservable<DoublyTimestampedData> CorrectTimestamps(IObservable<DoublyTimestampedData> timestamps, Options options)
        {
            return Observable.Create<DoublyTimestampedData>(observer =>
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
