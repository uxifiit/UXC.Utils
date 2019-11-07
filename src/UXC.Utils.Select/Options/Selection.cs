using UXC.Utils.Select.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UXI.Filters.Serialization.Converters;

namespace UXC.Utils.Select
{
    public class Selection
    {
        public Selection(string name, DateTimeOffset? from, DateTimeOffset? to)
        {
            Name = name;
            From = from;
            To = to;
        }


        public static Selection Parse(string name, string fromValue, string toValue, ITimestampStringConverter timestampConverter)
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

            return new Selection(name, from, to);
        }


        public string Name { get; set; }


        public DateTimeOffset? From { get; private set; }


        public DateTimeOffset? To { get; private set; }


        public static Selection Union(IEnumerable<Selection> selections)
        {
            // get minimum of From values or null, if selections were empty or there was a null value
            var from = selections.Select(s => s.From)
                          .DefaultIfEmpty(new DateTimeOffset?())
                          .Aggregate((result, current) =>
                          {
                              return (result.HasValue && current.HasValue)
                                     ? IComparableEx.Min(current.Value, result.Value)
                                     : new DateTimeOffset?();
                          });

            // get maximum of To values or null, if selections were empty or there was a null value
            var to = selections.Select(s => s.To)
                          .DefaultIfEmpty(new DateTimeOffset?())
                          .Aggregate((result, current) =>
                          {
                              return (result.HasValue && current.HasValue)
                                     ? IComparableEx.Max(current.Value, result.Value)
                                     : new DateTimeOffset?();
                          });

            return new Selection(null, from, to);
        }
    }
}
