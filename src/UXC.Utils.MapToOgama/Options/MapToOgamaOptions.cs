using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters.Options;
using UXI.GazeToolkit.Selection;
using UXI.Serialization;

namespace UXC.Utils.MapToOgama.Options
{
    class MapToOgamaOptions
        : IInputOptions
        , IOutputOptions
        , IScreenResolutionOptions
    {

        [Value(0, HelpText = "Path to the input file with UXC Gaze Data.", MetaName = "input", MetaValue = "GAZE_DATA_FILE", Required = false)] // If omitted, standard input stream is used. - It cannot be omitted because it is the first value.
        public virtual string InputFilePath { get; set; }


        [Option("format", Default = FileFormat.Default, HelpText = "Data format of the input file with gaze data.")]
        public virtual FileFormat InputFileFormat { get; set; }


        public virtual FileFormat DefaultInputFileFormat => FileFormat.JSON;


        [Option('o', "output", Default = null, HelpText = "Path to the output file. If omitted, standard output stream is used.", Required = false)]
        public virtual string OutputFilePath { get; set; }


        public virtual FileFormat OutputFileFormat { get { return FileFormat.CSV; } set { } }


        public virtual FileFormat DefaultOutputFileFormat => FileFormat.CSV;


        [Value(1, HelpText = "Path to the input file with UXC Session Events.", MetaName = "input", MetaValue = "SESSION_EVENTS_FILE", Required = true)]
        public virtual string InputSessionEventsFilePath { get; set; }


        [Option("format-session", Default = FileFormat.Default, HelpText = "Data format of the input file with session events.")]
        public virtual FileFormat InputSessionEventsFileFormat { get; set; }


        public virtual FileFormat DefaultInputSessionEventsFileFormat => FileFormat.JSON;


        [Value(2, HelpText = "Path to the input file with UXC Mouse Events.", MetaName = "input", MetaValue = "MOUSE_DATA_FILE", Required = false)]
        public virtual string InputMouseDataFilePath { get; set; }


        [Option("format-mouse", Default = FileFormat.Default, HelpText = "Data format of the input file with mouse events.")]
        public virtual FileFormat InputMouseDataFileFormat { get; set; }


        public virtual FileFormat DefaultInputMouseDataFileFormat => FileFormat.JSON;


        [Option('r', "resolution", Default = null, HelpText = "Screen resolution in pixels, in format [width]x[height]. This option overrides resolution dimensions specified separately. If not specified, the separate resolution parameters are used instead.", Required = false)]
        public string ScreenResolution { get; set; }


        [Option("resolution-width", Default = 1920, HelpText = "Screen resolution width in pixels.", Required = false)]
        public int ScreenResolutionWidth { get; set; }


        [Option("resolution-height", Default = 1200, HelpText = "Screen resolution height in pixels.", Required = false)]
        public int ScreenResolutionHeight { get; set; }


        [Option('e', "eye", Default = EyeSelectionStrategy.Average, HelpText = "Determines which eye to select from gaze data samples.", Required = false)]
        public EyeSelectionStrategy EyeSelectionStrategy { get; set; }


        [Option('s', "subject", HelpText = "Name of the participant, will appear in the SubjectName column in the output.", Required = true)]
        public string SubjectName { get; set; }
    }
}
