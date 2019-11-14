using CommandLine;
using System;
using UXI.Filters.Options;
using UXI.Serialization;

namespace UXC.Utils.CorrectTimestamps
{
    public class CorrectTimestampsOptions
        : IInputOptions
        , IOutputOptions
        , ILogOptions
        , ITimestampSerializationOptions
        , ITimestampsDiffStatisticsOptions
        , IDoublyTimestampedDataPayloadSerializationOptions
    {
        [Value(0, HelpText = "Path to the input file in JSON format. If omitted, standard input is used.", MetaName = "input file", MetaValue = "FILE", Required = false)]
        public string InputFilePath { get; set; }


        public FileFormat InputFileFormat
        {
            get { return FileFormat.JSON; }
            set { } // Input file format is forced to JSON and can not be changed. JSON is the only supported format here now.
        }


        public FileFormat DefaultInputFileFormat => FileFormat.JSON;


        [Option('o', "output", Default = null, HelpText = "Path to the output file. If omitted, standard output stream is used.", Required = false)]
        public string OutputFilePath { get; set; }


        public FileFormat OutputFileFormat
        {
            get { return InputFileFormat; }
            set { } // Output file format is forced to be the same as input file format."); 
        }


        public FileFormat DefaultOutputFileFormat => FileFormat.JSON;


        [Option('q', "quiet", Default = false, HelpText = "Suppress log messages.", Required = false)]
        public bool SuppressMessages { get; set; }


        [Option("timestamp-format", HelpText = "Format of timestamps in data.", Required = false)]
        public string TimestampFormat { get; set; }


        [Option("timestamp-field", HelpText = "Name of the timestamp field in data.", Required = false)]
        public string TimestampFieldName { get; set; }


        [Option("reference-timestamp-field", HelpText = "Name of a field in data with timestamp used for reference, for example: Timestamp, Ticks, etc.", Required = true)]
        public string ReferenceTimestampFieldName { get; set; }


        [Option("reference-timestamp-format", HelpText = "Format of reference timestamps in data.", Required = true)]
        public string ReferenceTimestampFormat { get; set; }


        public bool IsTimestampsDiffStatisticsEnabled => SuppressMessages == false;


        [Option('l', "log", Default = null, HelpText = "Path to the log file. If omitted, standard error stream is used. To suppress log messages, use the -q (--quiet) option.", Required = false)]
        public string TimestampsDiffStatisticsOutputFilePath { get; set; }


        [Option("log-format", Default = FileFormat.Default, HelpText = "Data format of the log. If not specified or the \"Default\" value used, the default format of each logger is used.", Required = false)]
        public FileFormat TimestampsDiffStatisticsOutputFileFormat { get; set; }


        public FileFormat DefaultTimestampsDiffStatisticsOutputFileFormat => FileFormat.CSV;
    }
}
