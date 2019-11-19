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
    class EyeDataCorrectionResultCsvConverter : CsvConverter<EyeDataCorrectionResult>
    {
        public override bool CanRead => false;

        protected override bool TryRead(CsvReader reader, CsvSerializerContext serializer, CsvHeaderNamingContext naming, ref EyeDataCorrectionResult result)
        {
            throw new NotSupportedException();
        }

        protected override void Write(EyeDataCorrectionResult data, CsvWriter writer, CsvSerializerContext serializer)
        {
            writer.WriteField(data.Validity);

            serializer.Serialize(writer, data.GazePoint2D);
            serializer.Serialize(writer, data.GazePoint3D);
            serializer.Serialize(writer, data.EyePosition3DRelative);
            serializer.Serialize(writer, data.EyePosition3D);

            writer.WriteField(data.PupilDiameter);
        }

        protected override void WriteHeader(CsvWriter writer, CsvSerializerContext serializer, CsvHeaderNamingContext naming)
        {
            writer.WriteField(naming.Get(nameof(EyeDataCorrectionResult.Validity)));

            serializer.WriteHeader<Point2>(writer, naming, nameof(EyeDataCorrectionResult.GazePoint2D));
            serializer.WriteHeader<PositionCorrectionResult>(writer, naming, nameof(EyeDataCorrectionResult.GazePoint3D));
            serializer.WriteHeader<Point3>(writer, naming, nameof(EyeDataCorrectionResult.EyePosition3DRelative));
            serializer.WriteHeader<PositionCorrectionResult>(writer, naming, nameof(EyeDataCorrectionResult.EyePosition3D));

            writer.WriteField(naming.Get(nameof(EyeDataCorrectionResult.PupilDiameter)));
        }
    }
}
