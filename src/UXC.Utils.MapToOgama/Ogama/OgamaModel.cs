using System;
using UXC.Utils.MapToOgama.Ogama.Events;
using UXI.GazeToolkit;

namespace UXC.Utils.MapToOgama.Ogama
{
    public class OgamaModel
    {
        public OgamaModel()
            : this(new State())
        {
        }

        public OgamaModel(string subjectName)
            : this(new State() { SubjectName = subjectName })
        {
        }

        public OgamaModel(State state)
        {
            _state = state;
        }


        private State _state;


        public void ReceiveEvent(OgamaEvent @event)
        {
            if (@event.Timestamp < _state.Timestamp)
            {
                throw new InvalidOperationException($"Timestamp of the received event is lower than the current timestamp of the state: {@event.Timestamp.ToString("o")} < {_state.Timestamp.ToString("o")}.");
            }

            var newState = _state.Clone();

            @event.Apply(newState);

            _state = newState;
        }


        public OgamaData GenerateData(DateTimeOffset referenceTimestamp)
        {
            return new OgamaData(
                _state.SubjectName,
                _state.TrialSequence,
                _state.TrialID,
                _state.TrialImage,
                (_state.Timestamp - referenceTimestamp).TotalMilliseconds,
                _state.PupilDia,
                _state.GazePos,
                _state.MousePos
            );
        }


        public class State
        {
            public DateTimeOffset Timestamp { get; set; }

            public string SubjectName { get; set; }

            public int TrialSequence { get; set; }

            public int TrialID { get; set; }

            public string TrialImage { get; set; }

            public Point2 PupilDia { get; set; }

            public Point2 GazePos { get; set; }

            public Point2 MousePos { get; set; }

            public State Clone()
            {
                return (State)this.MemberwiseClone();
            }
        }
    }
}