using System;

namespace Filter
{
    public interface ITimestampedData
    {
        DateTimeOffset Timestamp { get; }
    }
}
