using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using UXI.Serialization.Formats.Csv;
using UXI.Serialization.Formats.Csv.Converters;

namespace Selector.Serialization.Csv.Converters
{
    public class SelectionCsvConverter : CsvConverter<Selection>
    {
        protected override bool TryRead(CsvReader reader, CsvSerializerContext serializer, CsvHeaderNamingContext naming, ref Selection result)
        {
            DateTimeOffset? from, to;
            string name; 

            if (
                    reader.TryGetField<DateTimeOffset?>(naming.Get(nameof(Selection.From)), out from)
                &&  reader.TryGetField<DateTimeOffset?>(naming.Get(nameof(Selection.To)), out to)
                &&  reader.TryGetField<string>(naming.Get(nameof(Selection.Name)), out name)
               )
            {
                result = new Selection(name, from, to);
                return true;
            }

            return false;
        }

        protected override void Write(Selection data, CsvWriter writer, CsvSerializerContext serializer)
        {
            throw new NotImplementedException();
        }

        protected override void WriteHeader(CsvWriter writer, CsvSerializerContext serializer, CsvHeaderNamingContext naming)
        {
            throw new NotImplementedException();
        }
    }
}
