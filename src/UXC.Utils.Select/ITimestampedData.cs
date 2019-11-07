using System;

namespace UXC.Utils.Select
{
    public interface ITimestampedData
    {
        DateTimeOffset Timestamp { get; }
    }
}
