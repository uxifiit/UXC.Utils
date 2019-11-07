using UXI.Filters;

namespace Selector
{
    class SelectorContext 
        : FilterContext
    {
        public SelectorContext() 
            : base()
        {
        }

        public Selection Selection { get; set; }
    }
}
