using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using UXI.GazeToolkit;
using UXI.Serialization.Formats.Csv;
using UXI.Serialization.Formats.Csv.Converters;

namespace UXC.Utils.CorrectGazeDataPositions.Serialization.Csv
{
    class PositionCorrectionResultCsvConverter : CsvConverter<PositionCorrectionResult>
    {
        public override bool CanRead => false;

        protected override bool TryRead(CsvReader reader, CsvSerializerContext serializer, CsvHeaderNamingContext naming, ref PositionCorrectionResult result)
        {
            throw new NotSupportedException();
        }

        protected override void Write(PositionCorrectionResult data, CsvWriter writer, CsvSerializerContext serializer)
        {
            serializer.Serialize(writer, data.Measured);
            serializer.Serialize(writer, data.Calculated);

            writer.WriteField(data.Distance);
        }

        protected override void WriteHeader(CsvWriter writer, CsvSerializerContext serializer, CsvHeaderNamingContext naming)
        {
            serializer.WriteHeader<Point3>(writer, naming, nameof(PositionCorrectionResult.Measured));
            serializer.WriteHeader<Point3>(writer, naming, nameof(PositionCorrectionResult.Calculated));

            writer.WriteField(naming.Get(nameof(PositionCorrectionResult.Distance)));
        }
    }
}
