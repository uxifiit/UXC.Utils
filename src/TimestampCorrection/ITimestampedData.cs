using System;

namespace TimestampCorrection
{
    public interface ITimestampedData
    {
        DateTimeOffset Timestamp { get; }
    }
}
