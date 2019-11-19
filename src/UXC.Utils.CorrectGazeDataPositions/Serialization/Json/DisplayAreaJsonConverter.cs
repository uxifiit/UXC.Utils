using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UXI.GazeToolkit;
using UXI.Serialization.Formats.Json.Extensions;
using UXI.Serialization.Formats.Json.Converters;
using UXC.Utils.CorrectGazeDataPositions.Data;

namespace UXC.Utils.CorrectGazeDataPositions.Serialization.Json
{
    class DisplayAreaJsonConverter : GenericJsonConverter<DisplayArea>
    {
        protected override DisplayArea Convert(JToken token, JsonSerializer serializer)
        {
            JObject obj = (JObject)token;

            Point3 bottomLeft = obj.GetValue<Point3>(nameof(DisplayArea.BottomLeft), serializer);
            Point3 topLeft = obj.GetValue<Point3>(nameof(DisplayArea.TopLeft), serializer);
            Point3 topRight = obj.GetValue<Point3>(nameof(DisplayArea.TopRight), serializer);

            return new DisplayArea(bottomLeft, topLeft, topRight);
        }
    }
}
