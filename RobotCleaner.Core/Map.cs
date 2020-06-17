namespace RobotCleaner.Core
{
    public class Map
    {
        public Map(CoordinateRange rangeX, CoordinateRange rangeY)
        {
            MaxX = rangeX.Max;
            MinX = rangeX.Min;
            MaxY = rangeY.Max;
            MinY = rangeY.Min;
        }

        public int MaxX { get; }
        public int MinX { get; }
        public int MaxY { get; }
        public int MinY { get; }
    }
}
