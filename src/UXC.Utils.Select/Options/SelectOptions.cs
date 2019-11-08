using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using UXI.Filters.Options;
using UXI.Serialization;

namespace UXC.Utils.Select
{
    class SelectOptions
        : IInputOptions
        //, ILogOptions
        , ITimestampSerializationOptions
        , ITimestampedDataPayloadSerializationOptions
    {
        [Value(0, HelpText = "Path to the input file. If omitted, standard input stream is used.", MetaName = "input file", MetaValue = "FILE", Required = false)]
        public virtual string InputFilePath { get; set; }


        [Option("format", Default = FileFormat.JSON, HelpText = "Data format of the input.")]
        public virtual FileFormat InputFileFormat { get; set; }


        public virtual FileFormat DefaultInputFileFormat => FileFormat.JSON;


        [Option('o', "output", Default = null, HelpText = "Path to the output file. If omitted and --config option is not used, standard output stream is used. If multiple selections are defined with --config, the file path acts as a format string, use \"{name}\" in the path as a placeholder for selection names. If multiple selections are defined in --config, but the path does not contain placeholder, selection' name is appended to the path before extension.", Required = false)]
        public virtual string OutputFilePath { get; set; }


        //[Option('q', "quiet", Default = false, HelpText = "Suppress log messages.", Required = false)]
        //public virtual bool SuppressMessages { get; set; }


        [Option("timestamp-format", HelpText = "Format of timestamps in data.", Required = false)]
        public virtual string TimestampFormat { get; set; }


        [Option("timestamp-field", Default = "Timestamp", HelpText = "Name of the timestamp field in data.", Required = false)]
        public virtual string TimestampFieldName { get; set; }


        [Option("timestamp-from", Default = null, HelpText = "Minimum timestamp of the data. Must be in the same format as specified with the --timestamp-format option.", Required = false)]
        public string FromTimestamp { get; set; }


        [Option("timestamp-to", Default = null, HelpText = "Maximum timestamp of the data. Must be in the same format as specified with the --timestamp-format option.", Required = false)]
        public string ToTimestamp { get; set; }


        [Option('c', "config", HelpText = "Path to the config file with selections.", Required = false)]
        public string ConfigFilePath { get; set; }


        [Option('n', "name", Default = null, HelpText = "Name of the selection range specified with --timestamp-from and --timestamp-to, used to replace the {name} placeholder in output path.", Required = false)]
        public string Name { get; set; }
    }
}
