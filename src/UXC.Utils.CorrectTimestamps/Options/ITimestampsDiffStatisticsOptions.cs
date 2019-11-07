using UXI.Serialization;

namespace UXC.Utils.CorrectTimestamps
{
    public interface ITimestampsDiffStatisticsOptions
    {
        bool IsTimestampsDiffStatisticsEnabled { get; }

        string TimestampsDiffStatisticsOutputFilePath { get; set; }

        FileFormat TimestampsDiffStatisticsOutputFileFormat { get; set; }

        FileFormat DefaultTimestampsDiffStatisticsOutputFileFormat { get; }
    }
}
