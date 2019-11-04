using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Selector.Configuration;
using Selector.Observers;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Filters.Serialization.Converters;

namespace Selector
{
    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<SelectorOptions>
            (
                // filter:
                new RelayFilter<TimestampedDataPayload, TimestampedDataPayload, SelectorOptions>((source, _, context) => Select(source, context)),

                // configurations:
                new TimestampedDataPayloadSerializationConfiguration(),
                new RelayFilterConfiguration<SelectorOptions>(Configure)
            ).Execute(args);
        }


        private static IObservable<TimestampedDataPayload> Select(IObservable<TimestampedDataPayload> source, FilterContext context)
        {
            var result = source;

            var selection = context.GlobalSelection;
            if (selection != null)
            {
                if (selection.From.HasValue)
                {
                    result = result.Where(r => r.Timestamp >= selection.From.Value);
                }

                if (selection.To.HasValue)
                {
                    result = result.Where(r => r.Timestamp < selection.To.Value);
                }
            }

            return result;
        }


        private static void Configure(FilterContext context, SelectorOptions options)
        {

            // read from options or config file
            var selections = Enumerable.Empty<Selection>();

            if (String.IsNullOrWhiteSpace(options.ConfigFilePath))
            {
                selections = ReadSelectionFromOptions(options);
            }
            else
            {
                selections = ReadSelectionsFromConfigFile(context, options.ConfigFilePath);
            }

            if (selections.Any())
            {
                var observers = CreateObserversForSelections(selections, options).ToList();
                
                observers.ForEach(context.Observers.Add);

                context.GlobalSelection = Selection.Union(selections);
            }
        }


        private static object CreateObserversForSelections(IEnumerable<Selection> selections, SelectorOptions options)
        {



            var output = UXI.Filters.Common.FileHelper.DescribeOutput(
                           options.OutputFilePath,
                           options.OutputFileFormat,
                           options.DefaultOutputFileFormat,
                           typeof(TimestampedDataPayload),
                           Console.Out
                       );

            var observer = new FilteringObserver(selection, output);
        }

        private static IEnumerable<Selection> ReadSelectionFromOptions(SelectorOptions options)
        {
            ITimestampStringConverter timestampConverter = TimestampStringConverterResolver.Default.Resolve(options.TimestampFormat);

            var selection = Selection.Parse(options.FromTimestamp, options.ToTimestamp, timestampConverter);

            return new[] { selection };
        }


        private static IReadOnlyCollection<Selection> ReadSelectionsFromConfigFile(FilterContext context, string path)
        {
            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException($"Config file not found at the location: {path}");
            }

            var configSelections = context.IO.ReadInput<Selection>(path, UXI.Serialization.FileFormat.Default);

            return configSelections.ToArray();
        }


        /*
            name
            from
            to
            file (optional)
            
            if no file, use format + name, default format is {name}.JSON
            if even no name, use index as name
            if no format, use output file as format, add suffix ".{name}" before extension






            
         */

        private static void x()
        {
            IEnumerable<Selection> selections = null;

            // get main selection
            bool hasMinimum = selections.Select(s => s.From).Contains(null) == false;
            bool hasMaximum = selections.Select(s => s.To).Contains(null) == false;

            if (hasMinimum)
            {

            }



        }
    }
}
