using RobotCleaner.Core;
using System;
using System.Collections.Generic;

namespace RobotCleaner.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // The max and min coordinates that the robot will use
            var cordRange = new CoordinateRange(-100000, 100000);
            var commandManager = new CommandManager(
                maxCommands: 10000, 
                rangeX: cordRange, 
                rangeY: cordRange);
               
            // Collect input from user
            var commandModel = commandManager.CollectInput();


            var startingPosition = new Position(-100000, -100000);
            var movementTracker = new MovementTracker(startingPosition);
            var map = new Map(100000, -100000, 100000, -100000);

            var commands = new List<Command>
            {
                new Command
                {
                    Direction = Direction.South,
                    Steps = 2,
                },

                new Command
                {
                    Direction = Direction.West,
                    Steps = 5
                },
                new Command
                {
                    Direction = Direction.East,
                    Steps = 4
                }
            };

            // Direction  (E, W, S, N)
            // and steps (0 < s < 100.000)

            var robot = new Robot(commands, map, startingPosition, movementTracker);
            robot.RunCommands();
            robot.PrintCleaningReport();
            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }
    }
}
