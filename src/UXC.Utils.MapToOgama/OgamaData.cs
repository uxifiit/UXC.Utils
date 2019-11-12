using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Core.Data;

namespace UXC.Utils.MapToOgama
{

    public class OgamaDataGenerator
    {

    }

    public class OgamaEventState
    {
        public string Event { get; set; }

        string SubjectName { get; set; }

        int TrialSequence { get; set; }

        int TrialID { get; set; }

        string TrialImage { get; set; }

        double Time { get; set; }

        Point2 PupilDia { get; set; }

        Point2 GazePos { get; set; }

        Point2 MousePos { get; set; }

        public OgamaEventState Clone()
        {
            return (OgamaEventState)this.MemberwiseClone();
        }
    }


    public class OgamaData
    {
        string SubjectName { get; set; }

        int TrialSequence { get; set; }
        
        int TrialID { get; set; }

        string TrialImage { get; set; }

        double Time { get; set; }

        Point2 PupilDia { get; set; }

        Point2 GazePos { get; set; }

        Point2 MousePos { get; set; }

       
    }
}