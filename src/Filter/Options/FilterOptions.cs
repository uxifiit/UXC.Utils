using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using UXI.Filters.Serialization.Converters;

namespace Filter
{
    class Selection
    {
        public static Selection Parse(string fromValue, string toValue, ITimestampStringConverter timestampConverter)
        {
            if (timestampConverter == null)
            {
                throw new ArgumentNullException(nameof(timestampConverter));
            }

            DateTimeOffset? from = null;
            DateTimeOffset? to   = null;

            if (String.IsNullOrWhiteSpace(fromValue) == false)
            {
                from = timestampConverter.Convert(fromValue);
            }

            if (String.IsNullOrWhiteSpace(toValue) == false)
            {
                to = timestampConverter.Convert(toValue);
            }

            return new Selection()
            {
                FromTimestamp = from,
                ToTimestamp = to
            };
        }


        public DateTimeOffset? FromTimestamp { get; private set; }


        public DateTimeOffset? ToTimestamp { get; private set; }
    }


    class FilterOptions
        : BaseOptions
        , ITimestampedDataPayloadSerializationOptions
    {
        [Option("timestamp-from", Default = false, HelpText = "Minimum timestamp of the data. Must be in the same format as specified with the --timestamp-format option.", Required = false)]
        public string FromTimestamp { get; set; }


        [Option("timestamp-to", Default = false, HelpText = "Maximum timestamp of the data. Must be in the same format as specified with the --timestamp-format option.", Required = false)]
        public string ToTimestamp { get; set; }


        [Option("timestamp-field", HelpText = "Name of the timestamp field in data.", Required = false)]
        public virtual string TimestampFieldName { get; set; }
    }
}
