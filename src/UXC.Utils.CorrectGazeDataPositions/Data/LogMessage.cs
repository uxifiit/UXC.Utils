using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.GazeToolkit;

namespace UXC.Utils.CorrectGazeDataPositions.Data
{
    class LogMessage
    {
        public LogMessage(DateTimeOffset timestamp, string message)
        {
            Timestamp = timestamp;
            Message = message;
        }

        public string Message { get; }

        public DateTimeOffset Timestamp { get; }
    }
}
