using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters;
using UXI.Filters.Configuration;
using UXI.Serialization;
using UXI.Serialization.Formats.Csv.Configurations;
using UXI.Serialization.Extensions;
using TimestampCorrection.Serialization.Csv.Converters;
using TimestampCorrection.Statistics;

namespace TimestampCorrection.Configuration
{
    public class TimestampsDiffStatisticsObserverConfiguration : FilterConfiguration<ITimestampsDiffStatisticsOptions>
    {
        protected override void ConfigureOverride(FilterContext context, ITimestampsDiffStatisticsOptions options)
        {
            if (options.IsTimestampsDiffStatisticsEnabled)
            {
                AddConverters(context);
                AddObserver(context, options);
            }
        }


        private static void AddObserver(FilterContext context, ITimestampsDiffStatisticsOptions options)
        {
            var writer = UXI.Filters.Common.FileHelper.OpenFileWriter(options.TimestampsDiffStatisticsOutputFilePath)
                         ?? Console.Error;
            var format = UXI.Filters.Common.FileHelper.ResolveFormat(
                             options.TimestampsDiffStatisticsOutputFilePath,
                             options.TimestampsDiffStatisticsOutputFileFormat,
                             options.DefaultTimestampsDiffStatisticsOutputFileFormat
                         );

            var output = new OutputDescriptor(writer, format, typeof(TimestampsDiff));

            context.Observers.Add(new TimestampsDiffStatisticsObserver(output));
        }


        private void AddConverters(FilterContext context)
        {
            context.IO
                   .Formats
                   .GetOrDefault(FileFormat.CSV)?
                   .Configurations
                   .Add(new CsvConvertersSerializationConfiguration(new TimestampsDiffCsvConverter()));
        }
    }
}
