using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.GazeToolkit;

namespace UXC.Utils.MapToOgama.Ogama
{
    public class OgamaData
    {
        public OgamaData
            (
                string subjectName,
                int trialSequence,
                int trialID,
                string trialImage,
                double time,
                Point2 pupilDia,
                Point2 gazePos,
                Point2 mousePos
            )
        {
            SubjectName = subjectName;
            TrialSequence = trialSequence;
            TrialID = trialID;
            TrialImage = trialImage;
            Time = time;
            PupilDia = pupilDia;
            GazePos = gazePos;
            MousePos = mousePos;
        }

        string SubjectName { get; }

        int TrialSequence { get; }
        
        int TrialID { get; }

        string TrialImage { get; }

        double Time { get; }

        Point2 PupilDia { get; }

        Point2 GazePos { get; }

        Point2 MousePos { get; }
    }
}