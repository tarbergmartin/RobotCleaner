using System.Collections.Generic;

namespace RobotCleaner.Core
{
    public class Robot
    {
        private readonly List<Command> _commands;
        private readonly Map _map;
        private readonly MovementTracker _movementTracker;
        private Position _currentPosition;

        public Robot(CommandModel commandModel, Map map, MovementTracker movementTracker)
        {
            _commands = commandModel.Commands;
            _currentPosition = commandModel.StartingPosition;
            _map = map;
            _movementTracker = movementTracker;
        }

        public void RunCommands()
        {
            foreach (var command in _commands)
            {
                for (var i = 0; i < command.Steps; i++)
                {
                    Move(command.Direction);

                    // If robot attempts to go outside of the map, adjust position and stop further movement
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
            var copyOfPosition = new Position(_currentPosition.X, _currentPosition.Y);

            if (_currentPosition.X > _map.MaxX) _currentPosition = new Position(_map.MaxX, _currentPosition.Y);
            if (_currentPosition.X < _map.MinX) _currentPosition = new Position(_map.MinX, _currentPosition.Y);
            if (_currentPosition.Y > _map.MaxY) _currentPosition = new Position(_currentPosition.X, _map.MaxY);
            if (_currentPosition.Y < _map.MinY) _currentPosition = new Position(_currentPosition.X, _map.MinY);

            // This checks if the robot attempted to go outside the map
            if (_currentPosition.X != copyOfPosition.X || _currentPosition.Y != copyOfPosition.Y)
                isValidPosition = false;

            return isValidPosition;
        }
    }
}
