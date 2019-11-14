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
    public abstract class ConvertOptions
        : IInputOptions
        //, ILogOptions
        , IOutputOptions
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


        [Option("format-pretty", Default = false, HelpText = "Enables pretty formatting of outputs. If the output format (--output-format) is set to JSON, the JSON is indented.", Required = false)]
        public virtual bool IsPrettyFormatEnabled { get; set; }


        //[Option('q', "quiet", Default = false, HelpText = "Suppress log messages.", Required = false)]
        //public virtual bool SuppressMessages { get; set; }
    }



    [Verb("gaze")]
    public class ConvertGazeDataOptions : ConvertOptions { }



    [Verb("external")]
    public class ConvertExternalEventDataOptions : ConvertOptions { }



    [Verb("keyboard")]
    public class ConvertKeyboardEventDataOptions : ConvertOptions { }

    

    [Verb("mouse")]
    public class ConvertMouseEventDataOptions : ConvertOptions { }
}
