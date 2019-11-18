using System;

namespace UXC.Utils.MapToOgama.Data.Ogama.Events
{
    public abstract class OgamaEvent : IComparable, IComparable<OgamaEvent>
    {
        public abstract DateTimeOffset Timestamp { get; }

        public virtual void Apply(OgamaModel.State state)
        {
            state.Timestamp = Timestamp;
        }

        public int CompareTo(OgamaEvent other)
        {
            return this.Timestamp.CompareTo(other.Timestamp);
        }

        public int CompareTo(object obj)
        {
            return CompareTo((OgamaEvent)obj);
        }
    }
}