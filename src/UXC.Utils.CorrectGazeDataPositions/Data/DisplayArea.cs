﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXI.GazeToolkit;

namespace UXC.Utils.CorrectGazeDataPositions.Data
{
    public class DisplayArea
    {
        public DisplayArea(Point3 bottomLeft, Point3 topLeft, Point3 topRight)
        {
            BottomLeft = bottomLeft;
            TopLeft = topLeft;
            TopRight = topRight;
        }

        public Point3 BottomLeft { get; }
        public Point3 TopLeft { get; }
        public Point3 TopRight { get; }
    }

}