using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters.Options;
using UXI.Serialization;

namespace UXC.Utils.Convert
{
    abstract class ConvertOptions
        : IInputOptions
        //, ILogOptions
        , IOutputOptions // we handle the output configuration
        , IPrettyFormatOptions
    {
        [Value(0, HelpText = "Path to the input file. If omitted, standard input stream is used.", MetaName = "input file", MetaValue = "FILE", Required = false)]
        public virtual string InputFilePath { get; set; }


        [Option("format", Default = FileFormat.Default, HelpText = "Data format of the input.")]
        public virtual FileFormat InputFileFormat { get; set; }


        public virtual FileFormat DefaultInputFileFormat => FileFormat.JSON;


        [Option('o', "output", Default = null, HelpText = "Path to the output file. If omitted, standard output stream is used.", Required = false)]
        public virtual string OutputFilePath { get; set; }


        [Option("output-format", Default = FileFormat.Default, HelpText = "Data format of the output.", Required = false)]
        public virtual FileFormat OutputFileFormat { get; set; }


        public virtual FileFormat DefaultOutputFileFormat => FileFormat.JSON;


        //[Option('q', "quiet", Default = false, HelpText = "Suppress log messages.", Required = false)]
        //public virtual bool SuppressMessages { get; set; }


        [Option("format-pretty", Default = false, HelpText = "Enables pretty formatting of outputs. If any output (for example --output-format, --log-format) is set to JSON, the JSON is indented.", Required = false)]
        public virtual bool IsPrettyFormatEnabled { get; set; }
    }



    [Verb("gaze")]
    class ConvertGazeDataOptions : ConvertOptions { }



    [Verb("external")]
    class ConvertExternalEventDataOptions : ConvertOptions { }



    [Verb("keyboard")]
    class ConvertKeyboardEventDataOptions : ConvertOptions { }

    

    [Verb("mouse")]
    class ConvertMouseEventDataOptions : ConvertOptions { }
}
