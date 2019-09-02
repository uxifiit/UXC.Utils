using UXI.Filters.Options;

namespace Filter
{
    public interface ITimestampedDataPayloadSerializationOptions : ITimestampSerializationOptions
    {
        string TimestampFieldName { get; set; }
    }
}
