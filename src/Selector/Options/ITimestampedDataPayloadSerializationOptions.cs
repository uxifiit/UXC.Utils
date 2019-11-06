using UXI.Filters.Options;

namespace Selector
{
    public interface ITimestampedDataPayloadSerializationOptions : ITimestampSerializationOptions
    {
        string TimestampFieldName { get; set; }
    }
}
