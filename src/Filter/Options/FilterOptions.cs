using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace Filter
{
    class FilterOptions
        : BaseOptions
        , ITimestampedDataPayloadSerializationOptions
    {
        [Option("timestamp-from", Default = false, HelpText = "Minimum timestamp of the data. Must be in the same format as specified with the --timestamp-format option.", Required = false)]
        public string FromTimestampString { get; set; }


        public DateTimeOffset? FromTimestamp { get; set; }


        [Option("timestamp-to", Default = false, HelpText = "Maximum timestamp of the data. Must be in the same format as specified with the --timestamp-format option.", Required = false)]
        public string ToTimestampString { get; set; }


        public DateTimeOffset? ToTimestamp { get; set; }


        [Option("timestamp-field", HelpText = "Name of the timestamp field in data.", Required = false)]
        public virtual string TimestampFieldName { get; set; }
    }
}
