using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.Filters;
using UXI.Filters.Observers;

namespace Filter.Observers
{
    class FilteringObserver : FilterObserver
    {
        private readonly Selection _selection;

        public FilteringObserver(Selection selection, OutputDescriptor output) 
            : base(output)
        {
            _selection = selection;
        }


        protected override IObserver<object> CreateOutputObserver(IObserver<object> resultsObserver)
        {
            return System.Reactive.Observer.Create<object>(value =>
            {
                if (value is TimestampedDataPayload)
                {
                    var payload = (TimestampedDataPayload)value;
                    if (
                            (_selection.FromTimestamp.HasValue == false || _selection.FromTimestamp.Value < payload.Timestamp)
                         && (_selection.ToTimestamp.HasValue == false   || _selection.ToTimestamp.Value  >= payload.Timestamp)
                       )
                    {
                        resultsObserver.OnNext(value);
                    }
                }
            }, e => resultsObserver.OnError(e), () => resultsObserver.OnCompleted());
        }
    }
}
