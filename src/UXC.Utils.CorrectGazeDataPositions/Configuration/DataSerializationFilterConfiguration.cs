using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Utils.CorrectGazeDataPositions.Serialization.Csv;
using UXC.Utils.CorrectGazeDataPositions.Serialization.Json;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Serialization;
using UXI.Serialization.Extensions;
using UXI.Serialization.Formats.Csv.Configurations;
using UXI.Serialization.Formats.Json.Configurations;

namespace UXC.Utils.CorrectGazeDataPositions.Configuration
{
    public class DataSerializationFilterConfiguration : FilterConfiguration
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
                           new JsonConvertersSerializationConfiguration(
                               new LogMessageJsonConverter(),
                               new DisplayAreaChangedLogMessageJsonConverter(),
                               new DisplayAreaJsonConverter(),
                               new TrackBoxChangedLogMessageJsonConverter()
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
                           new CsvConvertersSerializationConfiguration(
                               new EyeDataCorrectionResultCsvConverter(),
                               new GazeDataCorrectionResultCsvConverter(),
                               new PositionCorrectionResultCsvConverter()
                           ) 
                       }
                   );
        }
    }
}
