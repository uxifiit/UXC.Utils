using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Filters.Serialization.Converters;
using UXI.Serialization;
using UXI.Serialization.Extensions;
using UXI.Serialization.Formats.Csv.Configurations;
using UXI.Serialization.Formats.Json.Configurations;
using TimestampCorrection.Serialization.Csv.Converters;
using TimestampCorrection.Serialization.Json.Converters;

namespace TimestampCorrection.Configuration
{
    public class DoublyTimestampedDataPayloadSerializationConfiguration : FilterConfiguration<IDoublyTimestampedDataPayloadSerializationOptions>
    {
        protected override void ConfigureOverride(FilterContext context, IDoublyTimestampedDataPayloadSerializationOptions options)
        {
            var referenceTimestampConverter = (String.IsNullOrWhiteSpace(options.ReferenceTimestampFormat) == false)
                                             ? TimestampStringConverterResolver.Default.Resolve(options.ReferenceTimestampFormat)
                                             : TimestampStringConverterResolver.Default.Resolve(options.TimestampFormat);

            var jsonConverter = new DoublyTimestampedDataPayloadJsonConverter
                                (
                                    options.TimestampFieldName,
                                    options.ReferenceTimestampFieldName,
                                    referenceTimestampConverter
                                );

            context.IO
                   .Formats
                   .GetOrDefault(FileFormat.JSON)?
                   .Configurations
                   .Add(new JsonConvertersSerializationConfiguration(jsonConverter));
        }
    }
}
