using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimestampCorrection
{
    public class TimestampCorrection
    {
        public static IEnumerable<DoublyTimestampedData> Correct(IEnumerable<DoublyTimestampedData> source)
        {
            List<DoublyTimestampedData> data = source.ToList();

            data.Sort((a, b) => a.ReferenceTimestamp.CompareTo(b.ReferenceTimestamp));

            long minTicksDiff = data.Select(d => d.Timestamp.ToUniversalTime().Ticks - d.ReferenceTimestamp.ToUniversalTime().Ticks)
                                    .DefaultIfEmpty(0)
                                    .Min();

            return data.Select(d => new DoublyTimestampedData(d.Payload, d.ReferenceTimestamp.AddTicks(minTicksDiff).ToOffset(d.Timestamp.Offset), d.ReferenceTimestamp));
        }
    }
}
