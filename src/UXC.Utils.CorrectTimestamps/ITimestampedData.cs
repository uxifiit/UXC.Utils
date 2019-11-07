using System;

namespace UXC.Utils.CorrectTimestamps
{
    public interface ITimestampedData
    {
        DateTimeOffset Timestamp { get; }
    }
}
