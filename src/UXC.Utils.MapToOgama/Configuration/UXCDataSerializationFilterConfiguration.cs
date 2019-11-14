using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Core.Data.Serialization.Formats.Csv;
using UXC.Core.Data.Serialization.Formats.Json;
using UXC.Utils.MapToOgama.Ogama;
using UXC.Utils.MapToOgama.Serialization.Json;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Serialization;
using UXI.Serialization.Configurations;
using UXI.Serialization.Extensions;
using UXI.Serialization.Formats.Csv;
using UXI.Serialization.Formats.Json.Configurations;

namespace UXC.Utils.MapToOgama.Configuration
{
    class UXCDataSerializationFilterConfiguration : FilterConfiguration
    {
        public override void Configure(FilterContext context, object options)
        {
            context.IO
                   .Formats
                   .GetOrDefault(FileFormat.JSON)?
                   .Configurations
                   .AddRange
                   (
                       new ISerializationConfiguration[] 
                       {
                           new UXCDataJsonConvertersSerializationConfiguration(),
                           new JsonConvertersSerializationConfiguration(
                               new SessionStepActionJsonConverter(),
                               new SessionStepEventJsonConverter()
                           )
                       }
                   );

            context.IO
                   .Formats
                   .GetOrDefault(FileFormat.CSV)?
                   .Configurations
                   .AddRange
                   (
                       new ISerializationConfiguration[]
                       {
                           new UXCDataCsvConvertersSerializationConfiguration(),
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
