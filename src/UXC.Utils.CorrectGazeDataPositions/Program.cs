using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Utils.CorrectGazeDataPositions.Data;
using UXC.Utils.CorrectGazeDataPositions.Configuration;
using UXI.Filters;
using UXI.GazeToolkit;
using UXI.GazeFilter.Configurations;
using UXI.Filters.Common.Extensions;
using System.Reactive.Linq;
using UXC.Core.Data.Compatibility.GazeToolkit;

namespace UXC.Utils.CorrectGazeDataPositions
{
    class Program
    {
        static int Main(string[] args)
        {
            return new SingleFilterHost<CorrectGazeDataPositionsContext, CorrectGazeDataPositionsOptions>(
                new RelayFilter<UXC.Core.Data.GazeData, GazeDataCorrectionResult, CorrectGazeDataPositionsOptions, CorrectGazeDataPositionsContext>(Correct),
                // UXC
                new UXCDataSerializationFilterConfiguration(),
                // GazeToolkit
                new TimestampedDataSerializationFilterConfiguration(),
                new GazeToolkitDataSerializationFilterConfiguration(),
                new PrettyFormatFilterConfiguration(),
                // Filter specific
                new DataSerializationFilterConfiguration(),
                new EyeTrackerLogsFilterConfiguration()
            ).Execute(args);
        }


        private static IObservable<GazeDataCorrectionResult> Correct(IObservable<UXC.Core.Data.GazeData> gazeData, CorrectGazeDataPositionsOptions options, CorrectGazeDataPositionsContext context)
        {
            return Observable.Create<GazeDataCorrectionResult>(observer =>
            {
                EyePosition3DFrom3DRelativeConverter eyePositionConverter = null;
                GazePoint3DFrom2DConverter gazePointConverter = null;

                var trackboxLogs    = context.IO
                                             .ReadInput<TrackBoxChangedLogMessage>(context.InputTrackBoxChanges, null)
                                             .Where(m => m != null);
                var displayAreaLogs = context.IO
                                             .ReadInput<DisplayAreaChangedLogMessage>(context.InputDisplayAreaChanges, null)
                                             .Where(m => m != null);
               
                var logsEnumerator = trackboxLogs.Merge<TrackBoxChangedLogMessage, DisplayAreaChangedLogMessage, LogMessage>
                (
                    displayAreaLogs,
                    (tb, da) => tb.Timestamp.CompareTo(da.Timestamp),
                    tb =>
                    {
                        eyePositionConverter = new EyePosition3DFrom3DRelativeConverter(tb.Content);
                        return tb;
                    },
                    da =>
                    {
                        gazePointConverter = new GazePoint3DFrom2DConverter(da.Content);
                        return da;
                    }
                ).GetEnumerator();

                bool hasNextLog = logsEnumerator.MoveNext();

                return gazeData.Subscribe(gaze =>
                {
                    while (hasNextLog && logsEnumerator.Current.Timestamp <= gaze.Timestamp)
                    {
                        hasNextLog = logsEnumerator.MoveNext();
                    }

                    //var result = new GazeData(
                    //    gaze.Timestamp,
                        
                    //);


                    var result = new GazeDataCorrectionResult(
                        gaze.Timestamp,
                        gaze.TrackerTicks,
                        new EyeDataCorrectionResult(
                            gaze.LeftEye.Validity.ToToolkit(),
                            gaze.LeftEye.GazePoint2D.ToToolkit(),
                            gaze.LeftEye.EyePosition3DRelative.ToToolkit(),
                            new PositionCorrectionResult(gaze.LeftEye.GazePoint3D.ToToolkit(), gazePointConverter.Convert(gaze.LeftEye.GazePoint2D.ToToolkit())),
                            new PositionCorrectionResult(gaze.LeftEye.EyePosition3D.ToToolkit(), eyePositionConverter.Convert(gaze.LeftEye.EyePosition3DRelative.ToToolkit())),
                            gaze.LeftEye.PupilDiameter
                        ),
                        new EyeDataCorrectionResult(
                            gaze.RightEye.Validity.ToToolkit(),
                            gaze.RightEye.GazePoint2D.ToToolkit(),
                            gaze.RightEye.EyePosition3DRelative.ToToolkit(),
                            new PositionCorrectionResult(gaze.RightEye.GazePoint3D.ToToolkit(), gazePointConverter.Convert(gaze.RightEye.GazePoint2D.ToToolkit())),
                            new PositionCorrectionResult(gaze.RightEye.EyePosition3D.ToToolkit(), eyePositionConverter.Convert(gaze.RightEye.EyePosition3DRelative.ToToolkit())),
                            gaze.RightEye.PupilDiameter
                        )
                    );

                    observer.OnNext(result);
                }, ex => { observer.OnError(ex); }, () => { observer.OnCompleted(); });
            });
        }
    }
}
