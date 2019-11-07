using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UXC.Utils.Select.Common.Extensions
{
    public static class IComparableEx
    {
        public static T Min<T>(this T current, T other) 
            where T : IComparable
        {
            return current.CompareTo(other) < 0 ? current : other;
        }


        public static T Max<T>(this T current, T other) 
            where T : IComparable
        {
            return current.CompareTo(other) > 0 ? current : other;
        }
    }
}
