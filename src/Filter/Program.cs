using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Filter.Configuration;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Filters.Serialization.Converters;

namespace Filter
{
    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<FilterOptions>
            (
                // filter:
                new RelayFilter<TimestampedDataPayload, TimestampedDataPayload, FilterOptions>(Filter),

                // configurations:
                new TimestampedDataPayloadSerializationConfiguration(),
                new RelayFilterConfiguration<FilterOptions>(Configure)
            ).Execute(args);
        }


        private static void Configure(FilterContext context, FilterOptions options)
        {
            ITimestampStringConverter timestampConverter = TimestampStringConverterResolver.Default.Resolve(options.TimestampFormat);

            if (String.IsNullOrWhiteSpace(options.FromTimestampString) == false)
            {
                options.FromTimestamp = timestampConverter.Convert(options.FromTimestampString);
            }

            if (String.IsNullOrWhiteSpace(options.ToTimestampString) == false)
            {
                options.ToTimestamp = timestampConverter.Convert(options.ToTimestampString);
            }
        }


        private static IObservable<TimestampedDataPayload> Filter(IObservable<TimestampedDataPayload> data, FilterOptions options, FilterContext context)
        {
            var result = data;

            if (options.FromTimestamp.HasValue)
            {
                result = result.SkipWhile(d => d.Timestamp < options.FromTimestamp.Value);
            }

            if (options.ToTimestamp.HasValue)
            {
                result = result.TakeWhile(d => d.Timestamp < options.ToTimestamp.Value);
            }

            return result;
        }
    }
}
