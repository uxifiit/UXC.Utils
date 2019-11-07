using UXI.Filters.Options;

namespace UXC.Utils.Select
{
    public interface ITimestampedDataPayloadSerializationOptions : ITimestampSerializationOptions
    {
        string TimestampFieldName { get; set; }
    }
}
