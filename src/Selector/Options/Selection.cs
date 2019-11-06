using System;
using UXI.Filters.Serialization.Converters;

namespace Selector
{
    class Selection
    {
        public Selection(string name, DateTimeOffset? from, DateTimeOffset? to)
        {
            Name = name;
            From = from;
            To = to;
        }


        public static Selection Parse(string fromValue, string toValue, ITimestampStringConverter timestampConverter)
        {
            if (timestampConverter == null)
            {
                throw new ArgumentNullException(nameof(timestampConverter));
            }

            DateTimeOffset? from = null;
            DateTimeOffset? to   = null;

            if (String.IsNullOrWhiteSpace(fromValue) == false)
            {
                from = timestampConverter.Convert(fromValue);
            }

            if (String.IsNullOrWhiteSpace(toValue) == false)
            {
                to = timestampConverter.Convert(toValue);
            }

            return new Selection(null, from, to);
        }


        public string Name { get; private set; }


        public DateTimeOffset? From { get; private set; }


        public DateTimeOffset? To { get; private set; }
    }
}
