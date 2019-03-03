using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using TimestampCorrection.Statistics;
using UXI.Serialization.Csv;
using UXI.Serialization.Csv.Converters;

namespace TimestampCorrection.Serialization.Csv.Converters
{
    class TimestampsDiffCsvConverter : CsvConverter<TimestampsDiff>
    {
        public override bool CanRead => false;

        public override object ReadCsv(CsvReader reader, Type objectType, CsvSerializerContext serializer, CsvHeaderNamingContext naming)
        {
            throw new NotSupportedException();
        }

        public override void WriteCsvHeader(CsvWriter writer, Type objectType, CsvSerializerContext serializer, CsvHeaderNamingContext naming)
        {
            writer.WriteField(naming.Get(nameof(TimestampsDiff.Count)));
            writer.WriteField(naming.Get(nameof(TimestampsDiff.Duration)));
            writer.WriteField(naming.Get(nameof(TimestampsDiff.NewDuration)));
            writer.WriteField(naming.Get(nameof(TimestampsDiff.StartOffset)));
            writer.WriteField(naming.Get(nameof(TimestampsDiff.EndOffset)));
            writer.WriteField(naming.Get(nameof(TimestampsDiff.DurationChange)));
        }

        protected override void WriteCsv(TimestampsDiff data, CsvWriter writer, CsvSerializerContext serializer)
        {
            writer.WriteField(data.Count);
            writer.WriteField(data.Duration);
            writer.WriteField(data.NewDuration);
            writer.WriteField(data.StartOffset);
            writer.WriteField(data.EndOffset);
            writer.WriteField(data.DurationChange);
        }
    }
}
