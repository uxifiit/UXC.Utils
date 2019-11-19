using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXC.Core.Data;

namespace UXC.Utils.MapToOgama.Data.Ogama
{
    public struct Point2f
    {
        public Point2f(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; }

        public float Y { get; }


        public static implicit operator Point2f(Point2 point)
        {
            return new Ogama.Point2f((float)point.X, (float)point.Y);
        }
    }
}
