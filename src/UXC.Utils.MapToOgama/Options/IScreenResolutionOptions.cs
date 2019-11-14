using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UXC.Utils.MapToOgama.Options
{
    public interface IScreenResolutionOptions
    {
        string ScreenResolution { get; }
        int ScreenResolutionWidth { get; }
        int ScreenResolutionHeight { get; }
    }
}
