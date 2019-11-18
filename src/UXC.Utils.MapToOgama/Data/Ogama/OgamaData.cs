using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Core.Data;

namespace UXC.Utils.MapToOgama.Data.Ogama
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

        public string SubjectName { get; }

        public int TrialSequence { get; }
        
        public int TrialID { get; }

        public string TrialImage { get; }

        public double Time { get; }

        public Point2 PupilDia { get; }

        public Point2 GazePos { get; }

        public Point2 MousePos { get; }
    }
}