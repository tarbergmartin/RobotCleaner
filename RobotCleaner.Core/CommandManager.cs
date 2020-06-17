using System;
using System.Collections.Generic;

namespace RobotCleaner.Core
{
    public class CommandManager
    {
        private readonly int _maxCommands;
        private readonly int _maxSteps;
        private readonly CoordinateRange _rangeX;
        private readonly CoordinateRange _rangeY;
        private CommandModel _commandModel;

        public CommandManager(int maxCommands, int maxSteps, CoordinateRange rangeX, CoordinateRange rangeY)
        {
            _maxCommands = maxCommands;
            _maxSteps = maxSteps;
            _rangeX = rangeX;
            _rangeY = rangeY;
        }

        public CommandModel CollectInput()
        {
            var numOfCommands = GetNumOfCommands();

            _commandModel = new CommandModel
            {
                Commands = new List<Command>(),
                StartingPosition = GetStartingPosition()
            };

            for (var i = 0; i < numOfCommands; i++)
            {
                _commandModel.Commands.Add(GetCommandInstructions());
            }

            return _commandModel;
        }

        private int GetNumOfCommands()
        {
            Console.WriteLine("How many commands will the robot perform?");
            var numOfCommands = int.Parse(Console.ReadLine());

            if (numOfCommands <= 0)
                numOfCommands = 1;

            else if (numOfCommands > _maxCommands)
                numOfCommands = _maxCommands;

            return numOfCommands;
        }

        private Position GetStartingPosition()
        {
            Console.WriteLine("What's the starting position?");
            var inputArray = Console.ReadLine().Split(' ');

            if (inputArray.Length == 2)
            {
                var x = int.Parse(inputArray[0]);
                var y = int.Parse(inputArray[1]);

                if (!_rangeX.IsWithin(x))
                {
                    throw new ArgumentException($"Starting position for x needs to be in between {_rangeX.Min} and {_rangeX.Max}.");
                }

                if (!_rangeY.IsWithin(y))
                {
                    throw new ArgumentException($"Starting position for y needs to be in between {_rangeY.Min} and {_rangeY.Max}.");
                }

                return new Position(x, y);
            }

            throw new ArgumentException($"Invalid starting position.");
        }

        private Command GetCommandInstructions()
        {
            Console.WriteLine("Please supply a command:");
            var inputArray = Console.ReadLine().Split(' ');

            if (inputArray.Length == 2)
            {
                var steps = int.Parse(inputArray[1]);

                if (steps > 0 && steps <= _maxSteps)
                {
                    var command = new Command();
                    var direction = inputArray[0];

                    switch (direction.ToUpper())
                    {
                        case "N":
                            command.Direction = Direction.North;
                            break;
                        case "E":
                            command.Direction = Direction.East;
                            break;
                        case "S":
                            command.Direction = Direction.South;
                            break;
                        case "W":
                            command.Direction = Direction.West;
                            break;
                        default:
                            throw new ArgumentException($"The direction is invalid.");
                    }

                    command.Steps = steps;
                    return command;
                }
            }

            throw new ArgumentException($"Invalid input for command.");
        }
    }
}
