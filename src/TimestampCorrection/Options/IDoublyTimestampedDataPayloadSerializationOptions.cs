using UXI.Filters.Options;

namespace TimestampCorrection
{
    public interface IDoublyTimestampedDataPayloadSerializationOptions : ITimestampSerializationOptions
    {
        string TimestampFieldName { get; set; }

        string ReferenceTimestampFieldName { get; set; }

        string ReferenceTimestampFormat { get; set; }
    }
}
