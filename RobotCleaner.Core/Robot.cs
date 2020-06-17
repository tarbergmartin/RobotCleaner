using System;
using System.Collections.Generic;

namespace RobotCleaner.Core
{
    public class Robot
    {
        private readonly List<Command> _commands;
        private readonly Map _map;
        private readonly MovementTracker _movementTracker;
        private Position _currentPosition;

        public Robot(List<Command> commands, Map map, Position startPosition, MovementTracker movementTracker)
        {
            _commands = commands;
            _map = map;
            _currentPosition = startPosition;
            _movementTracker = movementTracker;
        }

        public void RunCommands()
        {
            foreach (var command in _commands)
            {
                for (var i = 0; i < command.Steps; i++)
                {
                    Move(command.Direction);

                    // If robot attempted to go outside the map, adjust postion and stop further movement
                    if (!EnsureInsideMap())
                        break;

                    _movementTracker.AddTrackedMovement(_currentPosition);
                }
            }
        }

        public void PrintCleaningReport()
        {
            _movementTracker.PrintMovementHistory();
        }

        private void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    _currentPosition = new Position(_currentPosition.X, _currentPosition.Y + 1);
                    break;
                case Direction.East:
                    _currentPosition = new Position(_currentPosition.X + 1, _currentPosition.Y);
                    break;
                case Direction.South:
                    _currentPosition = new Position(_currentPosition.X, _currentPosition.Y - 1);
                    break;
                case Direction.West:
                    _currentPosition = new Position(_currentPosition.X - 1, _currentPosition.Y);
                    break;
            }
        }

        private bool EnsureInsideMap()
        {
            var isValidPosition = true;
            var positionCopy = new Position(_currentPosition.X, _currentPosition.Y);

            if (_currentPosition.X > _map.MaxX) _currentPosition = new Position(_map.MaxX, _currentPosition.Y);
            if (_currentPosition.X < _map.MinX) _currentPosition = new Position(_map.MinX, _currentPosition.Y);
            if (_currentPosition.Y > _map.MaxY) _currentPosition = new Position(_currentPosition.X, _map.MaxY);
            if (_currentPosition.Y < _map.MinY) _currentPosition = new Position(_currentPosition.X, _map.MinX);

            // If postion has changed, the robot tried to go outside of the map and that means the position is has changed and is invalid
            if (_currentPosition.X != positionCopy.X || _currentPosition.Y != positionCopy.Y)
                isValidPosition = false;

            return isValidPosition;
        }
    }
}
