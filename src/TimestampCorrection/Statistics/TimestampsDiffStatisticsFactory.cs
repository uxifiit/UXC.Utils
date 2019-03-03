using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.GazeFilter;
using UXI.GazeFilter.Statistics;

namespace TimestampCorrection.Statistics
{
    class TimestampsDiffStatisticsFactory : IFilterStatisticsFactory
    {
        public bool CanCreate(Type filterType) => true;

        public IFilterStatistics Create(IFilter filter, object options)
        {
            return new TimestampsDiffStatistics();
        }
    }
}
