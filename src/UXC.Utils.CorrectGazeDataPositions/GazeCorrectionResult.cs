using System;
using UXI.GazeToolkit;

namespace UXC.Utils.CorrectGazeDataPositions
{
    internal class GazeDataCorrectionResult : ITimestampedData
    {
        public GazeDataCorrectionResult(DateTimeOffset timestamp, long trackerTicks, EyeDataCorrectionResult leftEye, EyeDataCorrectionResult rightEye)
        {
            Timestamp = timestamp;
            TrackerTicks = trackerTicks;
            LeftEye = leftEye;
            RightEye = rightEye;
        }

        public EyeDataCorrectionResult LeftEye { get; }

        public EyeDataCorrectionResult RightEye { get; }

        public DateTimeOffset Timestamp { get; }

        public long TrackerTicks { get; }
    }


    public class EyeDataCorrectionResult
    {
        public EyeDataCorrectionResult(EyeValidity validity, Point2 gazePoint2D, Point3 eyePosition3DRelative, PositionCorrectionResult gazePosition3D, PositionCorrectionResult eyePosition3D, double pupilDiameter)
        {
            Validity = validity;
            GazePoint2D = gazePoint2D;
            EyePosition3DRelative = eyePosition3DRelative;
            GazePoint3D = gazePosition3D;
            EyePosition3D = eyePosition3D;
            PupilDiameter = pupilDiameter;
        }

        public Point2 GazePoint2D { get; }

        public PositionCorrectionResult GazePoint3D { get; }

        public Point3 EyePosition3DRelative { get; }

        public PositionCorrectionResult EyePosition3D { get; }

        public double PupilDiameter { get; }

        public EyeValidity Validity { get; }
    }


    public class PositionCorrectionResult
    {
        public PositionCorrectionResult(Point3 measured, Point3 calculated)
        {
            Measured = measured;
            Calculated = calculated;
            Distance = UXI.GazeToolkit.Utils.PointUtils.Vectors.GetLength(UXI.GazeToolkit.Utils.PointUtils.Vectors.GetVector(Measured, Calculated));
        }

        public Point3 Measured { get; }

        public Point3 Calculated { get; }

        public double Distance { get; }
    }
}