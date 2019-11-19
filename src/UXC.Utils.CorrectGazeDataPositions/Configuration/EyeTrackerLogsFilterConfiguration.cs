using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Utils.CorrectGazeDataPositions.Data;
using UXI.Filters;
using UXI.Filters.Common;
using UXI.Filters.Configuration;

namespace UXC.Utils.CorrectGazeDataPositions.Configuration
{
    class EyeTrackerLogsFilterConfiguration : FilterConfiguration<CorrectGazeDataPositionsContext, CorrectGazeDataPositionsOptions>
    {
        protected override void ConfigureOverride(CorrectGazeDataPositionsContext context, CorrectGazeDataPositionsOptions options)
        {
            context.InputDisplayAreaChanges = FileHelper.DescribeInput(
                                                  options.InputEyeTrackerLogFilePath,
                                                  options.InputEyeTrackerLogFileFormat,
                                                  options.DefaultInputEyeTrackerLogFileFormat,
                                                  typeof(DisplayAreaChangedLogMessage),
                                                  TextReader.Null
                                              );

            context.InputTrackBoxChanges = FileHelper.DescribeInput(
                                      options.InputEyeTrackerLogFilePath,
                                      options.InputEyeTrackerLogFileFormat,
                                      options.DefaultInputEyeTrackerLogFileFormat,
                                      typeof(TrackBoxChangedLogMessage),
                                      TextReader.Null
                                  );
        }
    }
}
