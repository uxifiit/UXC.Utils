using CommandLine;
using CommandLine.Text;
using UXI.Filters.Options;
using UXI.Serialization;

namespace UXC.Utils.CorrectGazeDataPositions
{
    internal class CorrectGazeDataPositionsOptions
        : IInputOptions
        , IOutputOptions
        , ITimestampSerializationOptions
    {
        [Value(1, HelpText = "Path to the input file with UXC Gaze Data. If omitted, standard input stream is used.", MetaName = "input file", MetaValue = "GAZE_DATA_FILE", Required = false)]
        public virtual string InputFilePath { get; set; }


        [Option("format", Default = FileFormat.Default, HelpText = "Data format of the input file with gaze data.")]
        public virtual FileFormat InputFileFormat { get; set; }


        public virtual FileFormat DefaultInputFileFormat => FileFormat.JSON;



        [Value(0, HelpText = "Path to the input file with UXC Gaze Data. If omitted, standard input stream is used.", MetaName = "input file", MetaValue = "EYE_TRACKER_LOG_FILE", Required = true)]
        public virtual string InputEyeTrackerLogFilePath { get; set; }


        public virtual FileFormat InputEyeTrackerLogFileFormat { get { return FileFormat.JSON; } set { } }


        public virtual FileFormat DefaultInputEyeTrackerLogFileFormat => FileFormat.JSON;


        [Option('o', "output", Default = null, HelpText = "Path to the output file. If omitted, standard output stream is used.", Required = false)]
        public virtual string OutputFilePath { get; set; }


        [Option("output-format", Default = FileFormat.Default, HelpText = "Data format of the output.", Required = false)]
        public virtual FileFormat OutputFileFormat { get; set; }


        public virtual FileFormat DefaultOutputFileFormat => FileFormat.CSV;


        [Option("format-pretty", Default = false, HelpText = "Enables pretty formatting of outputs. If the output format (--output-format) is set to JSON, the JSON is indented.", Required = false)]
        public virtual bool IsPrettyFormatEnabled { get; set; }

        public string TimestampFormat { get { return "date"; } set { } }
    }
}