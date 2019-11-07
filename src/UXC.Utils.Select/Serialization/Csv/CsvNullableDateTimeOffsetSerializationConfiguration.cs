using UXC.Utils.Select.Serialization.Csv.TypeConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters.Serialization.Converters;
using UXI.Serialization;
using UXI.Serialization.Configurations;
using UXI.Serialization.Formats.Csv;

namespace UXC.Utils.Select.Serialization.Csv
{
    public class CsvNullableDateTimeOffsetSerializationConfiguration : SerializationConfiguration<CsvSerializerContext>
    {
        public CsvNullableDateTimeOffsetSerializationConfiguration(ITimestampStringConverter timestampConverter)
        {
            TimestampConverter = timestampConverter;
        }


        public ITimestampStringConverter TimestampConverter { get; }


        protected override CsvSerializerContext Configure(CsvSerializerContext serializer, DataAccess access, object settings)
        {
            SetupDateTimeOffsetSerialization(serializer, TimestampConverter);

            return serializer;
        }


        private void SetupDateTimeOffsetSerialization(CsvSerializerContext serializer, ITimestampStringConverter timestampConverter)
        {
            if (timestampConverter != null)
            {
                serializer.Configuration.TypeConverterCache.AddConverter<DateTimeOffset>(new NullableDateTimeOffsetTypeConverter(timestampConverter));
            }
        }
    }
}
