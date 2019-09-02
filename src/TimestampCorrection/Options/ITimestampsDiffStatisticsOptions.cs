using UXI.Serialization;

namespace TimestampCorrection
{
    public interface ITimestampsDiffStatisticsOptions
    {
        bool IsTimestampsDiffStatisticsEnabled { get; }
        string TimestampsDiffStatisticsOutputFilePath { get; set; }
        FileFormat TimestampsDiffStatisticsOutputFileFormat { get; set; }
        FileFormat DefaultTimestampsDiffStatisticsOutputFileFormat { get; }
    }
}
