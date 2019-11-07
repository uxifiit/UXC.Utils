using UXI.Filters;

namespace UXC.Utils.Select
{
    class SelectContext 
        : FilterContext
    {
        public SelectContext() 
            : base()
        {
        }

        public Selection Selection { get; set; }
    }
}
