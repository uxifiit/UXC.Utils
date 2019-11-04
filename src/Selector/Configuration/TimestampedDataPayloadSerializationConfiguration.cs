using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Filters.Serialization.Converters;
using UXI.Serialization;
using UXI.Serialization.Formats.Csv.Configurations;
using UXI.Serialization.Extensions;
using UXI.Serialization.Formats.Json.Configurations;
using Selector.Serialization.Json.Converters;

namespace Selector.Configuration
{
    public class TimestampedDataPayloadSerializationConfiguration : FilterConfiguration<ITimestampedDataPayloadSerializationOptions>
    {
        protected override void ConfigureOverride(FilterContext context, ITimestampedDataPayloadSerializationOptions options)
        {
            var jsonConverter = new TimestampedDataPayloadJsonConverter
                                (
                                    options.TimestampFieldName
                                );

            context.IO
                   .Formats
                   .GetOrDefault(FileFormat.JSON)?
                   .Configurations
                   .Add(new JsonConvertersSerializationConfiguration(jsonConverter));
        }
    }
}
