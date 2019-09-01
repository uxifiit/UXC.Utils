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
using UXI.Serialization;
using UXI.Serialization.Csv;
using UXI.Serialization.Json;
using UXI.Filters;
using UXI.Serialization.Extensions;
using UXI.Filters.Common.Extensions;
using UXI.Filters.Options;
using UXI.Filters.Serialization.Converters;
using UXI.Serialization.Json.Configurations;
using UXI.Serialization.Csv.Configurations;
using TimestampCorrection.Configuration;

namespace TimestampCorrection
{
    public interface IDoublyTimestampedDataSerializationOptions : ITimestampSerializationOptions
    {
        string TimestampFieldName { get; set; }

        string ReferenceTimestampFieldName { get; set; }

        string ReferenceTimestampFormat { get; set; }
    }



    public interface ITimestampsDiffStatisticsOptions
    {
        bool IsTimestampsDiffStatisticsEnabled { get; }
        string TimestampsDiffStatisticsOutputFilePath { get; set; }
        FileFormat TimestampsDiffStatisticsOutputFileFormat { get; set; }
        FileFormat DefaultTimestampsDiffStatisticsOutputFileFormat { get; }
    }



    public class Options
    : IInputOptions
    , IOutputOptions
    , ILogOptions
    , ITimestampSerializationOptions
    , IDoublyTimestampedDataSerializationOptions
    , ITimestampsDiffStatisticsOptions
    //, IPrettyFormatOptions
    {
        [Value(0, HelpText = "Path to the input file. If omitted, standard input stream is used.", MetaName = "input file", MetaValue = "FILE", Required = false)]
        public virtual string InputFilePath { get; set; }


        public virtual FileFormat InputFileFormat
        {
            get { return FileFormat.Default; }
            set { throw new NotSupportedException("Input file format is forced to Default and can not be changed."); }
        }


        public virtual FileFormat DefaultInputFileFormat => FileFormat.JSON;


        [Option('o', "output", Default = null, HelpText = "Path to the output file. If omitted, standard output stream is used.", Required = false)]
        public virtual string OutputFilePath { get; set; }


        [Option("output-format", Default = FileFormat.Default, HelpText = "Data format of the output. If not specified or the \"Default\" value used, it is the same as input file format.", Required = false)]
        public virtual FileFormat OutputFileFormat
        {
            get { return FileFormat.Default; }
            set { throw new NotSupportedException("Output file format is forced to Default and can not be changed."); }
        }


        public virtual FileFormat DefaultOutputFileFormat => FileFormat.JSON;


        public bool IsTimestampsDiffStatisticsEnabled => SuppressMessages == false;


        [Option('l', "log", Default = null, HelpText = "Path to the log file. If omitted, standard error stream is used. To suppress log messages, use the -q (--quiet) option.", Required = false)]
        public virtual string TimestampsDiffStatisticsOutputFilePath { get; set; }


        [Option("log-format", Default = FileFormat.Default, HelpText = "Data format of the log. If not specified or the \"Default\" value used, the default format of each logger is used.", Required = false)]
        public virtual FileFormat TimestampsDiffStatisticsOutputFileFormat { get; set; }


        public virtual FileFormat DefaultTimestampsDiffStatisticsOutputFileFormat => FileFormat.CSV;


        [Option('q', "quiet", Default = false, HelpText = "Suppress log messages.", Required = false)]
        public virtual bool SuppressMessages { get; set; }


        [Option("timestamp-format", HelpText = "Format of timestamps in data.", Required = false)]
        public virtual string TimestampFormat { get; set; }


        [Option("timestamp-field", HelpText = "Name of the timestamp field in data.", Required = false)]
        public virtual string TimestampFieldName { get; set; }


        [Option("reference-timestamp-field", HelpText = "Name of a field in data with timestamp used for reference, for example: Timestamp, Ticks, etc.", Required = true)]
        public string ReferenceTimestampFieldName { get; set; }


        [Option("reference-timestamp-format", HelpText = "Format of reference timestamps in data.", Required = true)]
        public string ReferenceTimestampFormat { get; set; }

        //[Option("format-pretty", Default = false, HelpText = "Enables pretty formatting of outputs. If any output (for example --output-format, --log-format) is set to JSON, the JSON is indented.", Required = false)]
        //public virtual bool IsPrettyFormatEnabled { get; set; }
    }



    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<Options>
            (
                new RelayFilter<DoublyTimestampedData, DoublyTimestampedData, Options>(CorrectTimestamps),
                // configurations:
                new DoublyTimestampedDataSerializationConfiguration(),
                new TimestampsDiffStatisticsObserverConfiguration()
            ).Execute(args);
        }


        private static IObservable<DoublyTimestampedData> CorrectTimestamps(IObservable<DoublyTimestampedData> timestamps, Options options, FilterContext context)
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
