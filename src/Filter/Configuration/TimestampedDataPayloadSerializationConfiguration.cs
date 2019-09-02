using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filter.Serialization.Json.Converters;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Filters.Serialization.Converters;
using UXI.Serialization;
using UXI.Serialization.Csv.Configurations;
using UXI.Serialization.Extensions;
using UXI.Serialization.Json.Configurations;

namespace Filter.Configuration
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
