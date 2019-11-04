using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using TimestampCorrection.Statistics;
using UXI.Serialization.Formats.Csv;
using UXI.Serialization.Formats.Csv.Converters;

namespace TimestampCorrection.Serialization.Csv.Converters
{
    class TimestampsDiffCsvConverter : CsvConverter<TimestampsDiff>
    {
        public override bool CanRead => false;


        protected override bool TryRead(CsvReader reader, CsvSerializerContext serializer, CsvHeaderNamingContext naming, ref TimestampsDiff result)
        {
            throw new NotSupportedException();
        }


        protected override void Write(TimestampsDiff data, CsvWriter writer, CsvSerializerContext serializer)
        {
            writer.WriteField(data.Count);
            writer.WriteField(data.Duration);
            writer.WriteField(data.NewDuration);
            writer.WriteField(data.StartOffset);
            writer.WriteField(data.EndOffset);
            writer.WriteField(data.DurationChange);
        }


        protected override void WriteHeader(CsvWriter writer, CsvSerializerContext serializer, CsvHeaderNamingContext naming)
        {
            writer.WriteField(naming.Get(nameof(TimestampsDiff.Count)));
            writer.WriteField(naming.Get(nameof(TimestampsDiff.Duration)));
            writer.WriteField(naming.Get(nameof(TimestampsDiff.NewDuration)));
            writer.WriteField(naming.Get(nameof(TimestampsDiff.StartOffset)));
            writer.WriteField(naming.Get(nameof(TimestampsDiff.EndOffset)));
            writer.WriteField(naming.Get(nameof(TimestampsDiff.DurationChange)));
        }
    }
}
