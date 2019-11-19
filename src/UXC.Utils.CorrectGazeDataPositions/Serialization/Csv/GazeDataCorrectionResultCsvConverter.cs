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
    class GazeDataCorrectionResultCsvConverter : CsvConverter<GazeDataCorrectionResult>
    {
        public override bool CanRead => false;

        protected override bool TryRead(CsvReader reader, CsvSerializerContext serializer, CsvHeaderNamingContext naming, ref GazeDataCorrectionResult result)
        {
            throw new NotSupportedException();
        }

        protected override void Write(GazeDataCorrectionResult data, CsvWriter writer, CsvSerializerContext serializer)
        {
            //serializer.Serialize<ITimestampedData>(writer, data);
            writer.WriteField(data.Timestamp);
            writer.WriteField(data.TrackerTicks);
            serializer.Serialize<EyeDataCorrectionResult>(writer, data.LeftEye);
            serializer.Serialize<EyeDataCorrectionResult>(writer, data.RightEye);
        }

        protected override void WriteHeader(CsvWriter writer, CsvSerializerContext serializer, CsvHeaderNamingContext naming)
        {
            //serializer.WriteHeader<ITimestampedData>(writer, naming);
            writer.WriteField(naming.Get(nameof(GazeDataCorrectionResult.Timestamp)));
            writer.WriteField(naming.Get(nameof(GazeDataCorrectionResult.TrackerTicks)));
            serializer.WriteHeader<EyeDataCorrectionResult>(writer, naming, "Left");
            serializer.WriteHeader<EyeDataCorrectionResult>(writer, naming, "Right");
        }
    }
}
