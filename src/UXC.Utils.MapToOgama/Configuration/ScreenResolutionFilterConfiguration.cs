using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Utils.MapToOgama.Options;
using UXI.Filters.Configuration;
using UXI.GazeToolkit;

namespace UXC.Utils.MapToOgama.Configuration
{
    class ScreenResolutionFilterConfiguration : FilterConfiguration<MapToOgamaContext, IScreenResolutionOptions>
    {
        private static Point2 ReadScreenResolution(IScreenResolutionOptions options)
        {
            int width = options.ScreenResolutionWidth;
            int height = options.ScreenResolutionHeight;

            if (String.IsNullOrWhiteSpace(options.ScreenResolution) == false)
            {
                string[] resolution = options.ScreenResolution.Split(new[] { 'x', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (resolution.Length == 2)
                {
                    width = Convert.ToInt32(resolution[0]);
                    height = Convert.ToInt32(resolution[1]);
                }
            }

            return new Point2(width, height);
        }


        protected override void ConfigureOverride(MapToOgamaContext context, IScreenResolutionOptions options)
        {
            context.ScreenResolution = ReadScreenResolution(options);
        }
    }
}
