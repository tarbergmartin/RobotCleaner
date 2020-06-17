using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RobotCleaner.Core
{
    public class CommandManager
    {
        private readonly int _maxCommands;
        private readonly CoordinateRange _rangeX;
        private readonly CoordinateRange _rangeY;
        private CommandModel _commandModel;

        public CommandManager(int maxCommands, CoordinateRange rangeX, CoordinateRange rangeY)
        {
            _maxCommands = maxCommands;
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

            return null;
        }

        private int GetNumOfCommands()
        {
            var numOfCommands = int.Parse(Console.ReadLine());

            if (numOfCommands <= 0)
                numOfCommands = 1;

            else if (numOfCommands > _maxCommands)
                numOfCommands = _maxCommands;

            return numOfCommands;
        }

        private Position GetStartingPosition()
        {
            var inputArray = Console.ReadLine().Split(' ');

            if (inputArray.Length == 2)
            {
                var x = int.Parse(inputArray[0]);
                var y = int.Parse(inputArray[1]);

                if (!_rangeX.IsWithin(x))
                    x = _rangeX.GenerateValue();

                if (!_rangeY.IsWithin(y))
                    y = _rangeY.GenerateValue();

                return new Position(x, y);
            }

            return new Position(_rangeX.GenerateValue(), _rangeY.GenerateValue());
        }

        private Command GetCommandInstructions()
        {
            var input = 
            return null;
        }
    }
}
