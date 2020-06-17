using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleaner.Core
{
    public class CoordinateRange
    {
        public CoordinateRange(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public int Min { get; set; }
        public int Max { get; set; }

        public bool IsWithin(int value)
        {
            return value >= Min && value <= Max;
        }

        public int GenerateValue()
        {
            return new Random().Next(Min, Max);
        }
    }
}
