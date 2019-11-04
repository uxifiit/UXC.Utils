using System;

namespace Selector
{
    public interface ITimestampedData
    {
        DateTimeOffset Timestamp { get; }
    }
}
