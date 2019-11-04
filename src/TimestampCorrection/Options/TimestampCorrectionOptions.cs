using CommandLine;
using System;
using UXI.Serialization;

namespace TimestampCorrection
{
    public class TimestampCorrectionOptions 
        : BaseOptions
        , IDoublyTimestampedDataPayloadSerializationOptions
        , ITimestampsDiffStatisticsOptions
    {
        public override FileFormat InputFileFormat
        {
            get { return FileFormat.Default; }
            set { } // Input file format is forced to Default and can not be changed.
        }


        public override FileFormat DefaultInputFileFormat => FileFormat.JSON;


        public override FileFormat OutputFileFormat
        {
            get { return InputFileFormat; }
            set { } // Output file format is forced to be the same as input file format."); 
        }


        public override FileFormat DefaultOutputFileFormat => FileFormat.JSON;


        [Option("timestamp-field", HelpText = "Name of the timestamp field in data.", Required = false)]
        public virtual string TimestampFieldName { get; set; }


        [Option("reference-timestamp-field", HelpText = "Name of a field in data with timestamp used for reference, for example: Timestamp, Ticks, etc.", Required = true)]
        public string ReferenceTimestampFieldName { get; set; }


        [Option("reference-timestamp-format", HelpText = "Format of reference timestamps in data.", Required = true)]
        public string ReferenceTimestampFormat { get; set; }


        public bool IsTimestampsDiffStatisticsEnabled => SuppressMessages == false;


        [Option('l', "log", Default = null, HelpText = "Path to the log file. If omitted, standard error stream is used. To suppress log messages, use the -q (--quiet) option.", Required = false)]
        public virtual string TimestampsDiffStatisticsOutputFilePath { get; set; }


        [Option("log-format", Default = FileFormat.Default, HelpText = "Data format of the log. If not specified or the \"Default\" value used, the default format of each logger is used.", Required = false)]
        public virtual FileFormat TimestampsDiffStatisticsOutputFileFormat { get; set; }


        public virtual FileFormat DefaultTimestampsDiffStatisticsOutputFileFormat => FileFormat.CSV;
    }
}
