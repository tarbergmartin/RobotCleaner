using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleaner.Core
{
    public class MovementTracker
    {
        private readonly HashSet<Position> _trackedPositions;

        public MovementTracker(Position startPosition)
        {
            _trackedPositions = new HashSet<Position>
            {
                startPosition
            };
        }

        public void AddTrackedMovement(Position position)
        {
            _trackedPositions.Add(position);
        }

        public void PrintMovementHistory()
        {
            Console.WriteLine($"=> Cleaned: {_trackedPositions.Count}");
        }
    }
}
