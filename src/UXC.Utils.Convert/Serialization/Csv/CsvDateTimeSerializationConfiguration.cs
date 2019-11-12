using System;
using UXC.Utils.Convert.Serialization.Csv.TypeConverters;
using UXI.Serialization;
using UXI.Serialization.Configurations;
using UXI.Serialization.Formats.Csv;

namespace UXC.Utils.Convert.Serialization.Csv
{
    class CsvDateTimeSerializationConfiguration : SerializationConfiguration<CsvSerializerContext>
    {
        public CsvDateTimeSerializationConfiguration()
        {
        }


        protected override CsvSerializerContext Configure(CsvSerializerContext serializer, DataAccess access, Type dataType, object settings)
        {
            serializer.Configuration.TypeConverterCache.AddConverter<DateTime>(new DateTimeTypeConverter());

            return serializer;
        }
    }
}
