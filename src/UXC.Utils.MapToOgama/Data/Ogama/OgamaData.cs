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
                float time,
                Point2f pupilDia,
                Point2f gazePos,
                Point2f mousePos
            )
        {
            SubjectName = subjectName;
            TrialSequence = trialSequence;
            TrialID = trialID;
            TrialImage = trialImage;
            Time = time;
            PupilDiaX = (float)pupilDia.X;
            PupilDiaY = (float)pupilDia.Y;
            GazePosX = (float)gazePos.X;
            GazePosY = (float)gazePos.Y;
            MousePosX = (float)mousePos.X;
            MousePosY = (float)mousePos.Y;
        }

        public string SubjectName { get; }

        public int TrialSequence { get; }
        
        public int TrialID { get; }

        public string TrialImage { get; }

        public float Time { get; }

        public float PupilDiaX { get; }

        public float PupilDiaY { get; }

        public float GazePosX { get; }

        public float GazePosY { get; }

        public float MousePosX { get; }

        public float MousePosY  { get; }
    }
}