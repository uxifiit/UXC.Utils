using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.GazeFilter;
using UXI.GazeFilter.Statistics;

namespace GazeDataTimestampCorrection.Statistics
{
    class TimestampsDiffStatisticsFactory : IFilterStatisticsFactory
    {
        public bool CanCreate(Type type) => true;

        public IFilterStatistics Create(IFilter filter, object options)
        {
            return new TimestampsDiffStatistics();
        }
    }
}
