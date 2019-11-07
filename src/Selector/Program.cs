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
using UXI.Filters.Observers;
using UXI.Filters.Serialization.Converters;

namespace Selector
{
    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<SelectorContext, SelectorOptions>
            (
                // filter:
                new RelayFilter<TimestampedDataPayload, TimestampedDataPayload, SelectorOptions, SelectorContext>((source, _, context) => Select(source, context)),

                // configurations:
                new TimestampedDataPayloadSerializationConfiguration(),
                new SelectionSerializationConfiguration(),
                new RelayFilterConfiguration<SelectorContext, SelectorOptions>(Configure)
            ).Execute(args);
        }


        private static IObservable<TimestampedDataPayload> Select(IObservable<TimestampedDataPayload> source, SelectorContext context)
        {
            var result = source;

            var selection = context.Selection;
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


        private static void Configure(SelectorContext context, SelectorOptions options)
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

                context.Selection = Selection.Union(selections);
            }
        }


        private static IEnumerable<FilterObserver> CreateObserversForSelections(IEnumerable<Selection> selections, SelectorOptions options)
        {
            HashSet<string> paths = new HashSet<string>();
            List<FilteringObserver> observers = new List<FilteringObserver>();

            foreach (var selection in selections)
            {
                string path = options.OutputFilePath;
                string name = (selection.Name ?? String.Empty).Trim();

                if (String.IsNullOrWhiteSpace(path) && String.IsNullOrWhiteSpace(name) == false)
                {
                    path = options.InputFilePath;
                }

                if (String.IsNullOrWhiteSpace(path) == false)
                {
                    if (path.Contains("{name}"))
                    {
                        path = path.Replace("{name}", name);
                    }
                    else if (String.IsNullOrWhiteSpace(name) == false)
                    {
                        path = Path.GetFileNameWithoutExtension(path) + $".{name}" + Path.GetExtension(path);
                    }
                }

                // use only unique paths
                if (path != options.InputFilePath && paths.Add(path))
                {
                    var output = UXI.Filters.Common.FileHelper.DescribeOutput(
                                   path,
                                   options.InputFileFormat,
                                   options.DefaultInputFileFormat,
                                   typeof(TimestampedDataPayload),
                                   (String.IsNullOrWhiteSpace(path)) ? Console.Out : TextWriter.Null  // use Console.Out for empty path only
                               );

                    observers.Add(new FilteringObserver(selection, output));
                }
            }

            return observers;
        }


        private static IEnumerable<Selection> ReadSelectionFromOptions(SelectorOptions options)
        {
            ITimestampStringConverter timestampConverter = TimestampStringConverterResolver.Default.Resolve(options.TimestampFormat);

            var selection = Selection.Parse(options.Name, options.FromTimestamp, options.ToTimestamp, timestampConverter);

            return new[] { selection };
        }


        private static IReadOnlyCollection<Selection> ReadSelectionsFromConfigFile(FilterContext context, string path)
        {
            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException($"Config file not found at the location: {path}");
            }
            
            var configSelections = context.IO.ReadInput<Selection>(path, UXI.Filters.Common.FileHelper.ResolveFormatFromPath(path));

            return configSelections.ToArray();
        }
    }
}
