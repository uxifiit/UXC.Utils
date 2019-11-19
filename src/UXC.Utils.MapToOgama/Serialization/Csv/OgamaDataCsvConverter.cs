using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using UXC.Core.Data;
using UXC.Utils.MapToOgama.Data.Ogama;
using UXI.Serialization.Formats.Csv;
using UXI.Serialization.Formats.Csv.Converters;

namespace UXC.Utils.MapToOgama.Serialization.Csv
{
    class OgamaDataCsvConverter : CsvConverter<OgamaData>
    {
        public override bool CanRead => false;

        protected override bool TryRead(CsvReader reader, CsvSerializerContext serializer, CsvHeaderNamingContext naming, ref OgamaData result)
        {
            throw new NotSupportedException();
        }

        protected override void Write(OgamaData data, CsvWriter writer, CsvSerializerContext serializer)
        {
            writer.WriteField(data.SubjectName);
            writer.WriteField(data.TrialSequence);
            writer.WriteField(data.TrialID);
            writer.WriteField(data.TrialImage);
            writer.WriteField(data.Time);
            writer.WriteField(data.PupilDiaX);
            writer.WriteField(data.PupilDiaY);
            writer.WriteField(data.GazePosX);
            writer.WriteField(data.GazePosY);
            writer.WriteField(data.MousePosX);
            writer.WriteField(data.MousePosY);
        }

        protected override void WriteHeader(CsvWriter writer, CsvSerializerContext serializer, CsvHeaderNamingContext naming)
        {
            writer.WriteField(naming.Get(nameof(OgamaData.SubjectName)));
            writer.WriteField(naming.Get(nameof(OgamaData.TrialSequence)));
            writer.WriteField(naming.Get(nameof(OgamaData.TrialID)));
            writer.WriteField(naming.Get(nameof(OgamaData.TrialImage)));
            writer.WriteField(naming.Get(nameof(OgamaData.Time)));
            writer.WriteField(naming.Get(nameof(OgamaData.PupilDiaX)));
            writer.WriteField(naming.Get(nameof(OgamaData.PupilDiaY)));
            writer.WriteField(naming.Get(nameof(OgamaData.GazePosX)));
            writer.WriteField(naming.Get(nameof(OgamaData.GazePosY)));
            writer.WriteField(naming.Get(nameof(OgamaData.MousePosX)));
            writer.WriteField(naming.Get(nameof(OgamaData.MousePosY)));
        }
    }
}
