using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimestampCorrection.Serialization.Csv.Converters;
using TimestampCorrection.Serialization.Json.Converters;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Filters.Serialization.Converters;
using UXI.Serialization;
using UXI.Serialization.Csv.Configurations;
using UXI.Serialization.Extensions;
using UXI.Serialization.Json.Configurations;

namespace TimestampCorrection.Configuration
{
    public class DoublyTimestampedDataSerializationConfiguration : FilterConfiguration<IDoublyTimestampedDataSerializationOptions>
    {
        protected override void ConfigureOverride(FilterContext context, IDoublyTimestampedDataSerializationOptions options)
        {
            var referenceTimestampConverter = (String.IsNullOrWhiteSpace(options.ReferenceTimestampFormat) == false)
                                             ? TimestampStringConverterResolver.Default.Resolve(options.ReferenceTimestampFormat)
                                             : TimestampStringConverterResolver.Default.Resolve(options.TimestampFormat);

            var jsonConverter = new DoublyTimestampedDataJsonConverter
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
