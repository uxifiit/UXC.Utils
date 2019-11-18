using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Core.Data;
using UXC.Utils.MapToOgama.Data;
using UXC.Utils.MapToOgama.Data.UXC;
using UXC.Utils.MapToOgama.Options;
using UXI.Filters.Common;
using UXI.Filters.Configuration;

namespace UXC.Utils.MapToOgama.Configuration
{
    class AdditionalInputsFilterConfiguration : FilterConfiguration<MapToOgamaContext, MapToOgamaOptions>
    {
        protected override void ConfigureOverride(MapToOgamaContext context, MapToOgamaOptions options)
        {
            context.InputMouseData = FileHelper.DescribeInput(
                                        options.InputMouseDataFilePath,
                                        options.InputMouseDataFileFormat,
                                        options.DefaultInputMouseDataFileFormat,
                                        typeof(MouseEventData),
                                        TextReader.Null
                                    );

            context.InputSessionEvents = FileHelper.DescribeInput(
                                            options.InputSessionEventsFilePath,
                                            options.InputSessionEventsFileFormat,
                                            UXI.Serialization.FileFormat.JSON,
                                            typeof(SessionStepEvent),
                                            TextReader.Null
                                        );
    }
}
}
