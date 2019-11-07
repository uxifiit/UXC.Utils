using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UXC.Utils.CorrectTimestamps
{
    public class TimestampCorrection
    {
        public static IEnumerable<DoublyTimestampedDataPayload> Correct(IEnumerable<DoublyTimestampedDataPayload> source)
        {
            List<DoublyTimestampedDataPayload> data = source.ToList();

            data.Sort((a, b) => a.ReferenceTimestamp.CompareTo(b.ReferenceTimestamp));

            long minTicksDiff = data.Select(d => d.Timestamp.ToUniversalTime().Ticks - d.ReferenceTimestamp.ToUniversalTime().Ticks)
                                    .DefaultIfEmpty(0)
                                    .Min();

            return data.Select(d => new DoublyTimestampedDataPayload(
                                        d.Payload, 
                                        d.ReferenceTimestamp
                                         .AddTicks(minTicksDiff)
                                         .ToOffset(d.Timestamp.Offset),
                                        d.ReferenceTimestamp)
                              );
        }
    }
}
