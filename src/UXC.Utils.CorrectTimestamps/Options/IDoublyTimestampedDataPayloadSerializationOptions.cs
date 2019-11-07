using UXI.Filters.Options;

namespace UXC.Utils.CorrectTimestamps
{
    public interface IDoublyTimestampedDataPayloadSerializationOptions : ITimestampSerializationOptions
    {
        string TimestampFieldName { get; set; }

        string ReferenceTimestampFieldName { get; set; }

        string ReferenceTimestampFormat { get; set; }
    }
}
