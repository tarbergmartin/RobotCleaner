using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleaner.Core
{
    public class Map
    {
        public Map(int maxX, int minX, int maxY, int minY)
        {
            MaxX = maxX;
            MinX = minX;
            MaxY = maxY;
            MinY = minY;
        }

        public int MaxX { get; }
        public int MinX { get; }
        public int MaxY { get; }
        public int MinY { get; }
    }
}
