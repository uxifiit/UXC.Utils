using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UXC.Utils.CorrectGazeDataPositions.Data
{
    class TrackBoxChangedLogMessage : LogMessage
    {
        public TrackBoxChangedLogMessage(LogMessage logMessage, TrackBoxCoords trackbox) 
            : base(logMessage.Timestamp, logMessage.Message)
        {
            Content = trackbox;
        }

        public TrackBoxCoords Content { get; }
    }
}
