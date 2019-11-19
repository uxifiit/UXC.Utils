using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Core.Data.Serialization.Formats.Csv;
using UXC.Core.Data.Serialization.Formats.Json;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Serialization;
using UXI.Serialization.Configurations;
using UXI.Serialization.Extensions;
using UXI.Serialization.Formats.Csv;
using UXI.Serialization.Formats.Json.Configurations;

namespace UXC.Utils.CorrectGazeDataPositions.Configuration
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
                       }
                   );
        }
    }
}
