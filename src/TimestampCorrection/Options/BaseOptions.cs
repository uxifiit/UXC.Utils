using CommandLine;
using UXI.Serialization;
using UXI.Filters.Options;

namespace TimestampCorrection
{
    public class BaseOptions
        : IInputOptions
        , IOutputOptions
        , ILogOptions
        , ITimestampSerializationOptions
    {
        [Value(0, HelpText = "Path to the input file. If omitted, standard input is used.", MetaName = "input file", MetaValue = "FILE", Required = false)]
        public virtual string InputFilePath { get; set; }


        [Option("format", Default = FileFormat.JSON, HelpText = "Data format of the input.")]
        public virtual FileFormat InputFileFormat { get; set; }


        public virtual FileFormat DefaultInputFileFormat => FileFormat.JSON;


        [Option('o', "output", Default = null, HelpText = "Path to the output file. If omitted, standard output stream is used.", Required = false)]
        public virtual string OutputFilePath { get; set; }


        public virtual FileFormat OutputFileFormat { get { return InputFileFormat; } set { } }
        

        public virtual FileFormat DefaultOutputFileFormat => DefaultInputFileFormat;


        [Option('q', "quiet", Default = false, HelpText = "Suppress log messages.", Required = false)]
        public virtual bool SuppressMessages { get; set; }


        [Option("timestamp-format", HelpText = "Format of timestamps in data.", Required = false)]
        public virtual string TimestampFormat { get; set; }
    }
}
