using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters.Serialization.Converters;

namespace Selector.Serialization.Csv.TypeConverters
{
    class NullableDateTimeOffsetTypeConverter : ITypeConverter
    {
        private readonly ITimestampStringConverter _timestampConverter;

        public NullableDateTimeOffsetTypeConverter(ITimestampStringConverter timestampConverter)
        {
            _timestampConverter = timestampConverter;
        }


        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return String.IsNullOrWhiteSpace(text)
                 ? new DateTimeOffset?()
                 : _timestampConverter.Convert(text);
        }


        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return (null == value)
                 ? String.Empty
                 : _timestampConverter.ConvertBack((DateTimeOffset)value);
        }
    }
}
