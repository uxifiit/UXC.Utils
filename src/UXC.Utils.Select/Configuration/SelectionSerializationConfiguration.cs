using UXC.Utils.Select.Serialization.Csv;
using UXC.Utils.Select.Serialization.Csv.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Filters.Options;
using UXI.Filters.Serialization.Converters;
using UXI.Serialization;
using UXI.Serialization.Extensions;
using UXI.Serialization.Formats.Csv.Configurations;

namespace UXC.Utils.Select.Configuration
{
    class SelectionSerializationConfiguration : FilterConfiguration<ITimestampSerializationOptions>
    {
        protected override void ConfigureOverride(FilterContext context, ITimestampSerializationOptions options)
        {
            ITimestampStringConverter timestampConverter = TimestampStringConverterResolver.Default.Resolve(options.TimestampFormat);

            var converters = new ISerializationConfiguration[] {
                new CsvConvertersSerializationConfiguration(new SelectionCsvConverter())
            };


            context.IO
                   .Formats
                   .GetOrDefault(FileFormat.CSV)?
                   .Configurations
                   .AddRange(converters);
        }
    }
}
