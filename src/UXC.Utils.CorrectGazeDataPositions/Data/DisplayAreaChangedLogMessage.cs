using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.GazeToolkit;

namespace UXC.Utils.CorrectGazeDataPositions.Data
{
    class DisplayAreaChangedLogMessage : LogMessage
    {
        public DisplayAreaChangedLogMessage(LogMessage logMessage, DisplayArea displayArea)
            : base(logMessage.Timestamp, logMessage.Message)
        {
            Content = displayArea;
        }

        public DisplayArea Content { get; }
    }
}
