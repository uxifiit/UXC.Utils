using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Utils.MapToOgama.Data.Ogama;
using UXC.Utils.MapToOgama.Serialization.Csv;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Serialization;
using UXI.Serialization.Configurations;
using UXI.Serialization.Extensions;
using UXI.Serialization.Formats.Csv;
using UXI.Serialization.Formats.Csv.Configurations;

namespace UXC.Utils.MapToOgama.Configuration
{
    class OgamaDataSerializationFilterConfiguration : FilterConfiguration
    {
        public override void Configure(FilterContext context, object options)
        {
            context.IO
                  .Formats
                  .GetOrDefault(FileFormat.CSV)?
                  .Configurations
                  .AddRange
                  (
                      new ISerializationConfiguration[]
                      {
                           new CsvConvertersSerializationConfiguration(
                               new OgamaDataCsvConverter()
                           ),
                           new RelaySerializationConfiguration<CsvSerializerContext>(
                               (serializer, access, dataType, _) =>
                               {
                                   if (access == DataAccess.Write && dataType.Equals(typeof(OgamaData)))
                                   {
                                       serializer.Configuration.Delimiter = "\t";
                                   }
                                   return serializer;
                               }
                           )
                      }
                  );
        }
    }
}
