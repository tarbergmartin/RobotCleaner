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
    }
}
