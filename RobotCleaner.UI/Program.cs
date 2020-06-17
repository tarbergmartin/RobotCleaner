using RobotCleaner.Core;

namespace RobotCleaner.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // The max and min coordinates used for the office area
            var cordRange = new CoordinateRange(-100000, 100000);

            // Configure the manager that handles user input
            var commandManager = new CommandManager(
                maxCommands: 10000,
                maxSteps: 100000,
                rangeX: cordRange, 
                rangeY: cordRange);
               
            // Collect input from user
            var commandModel = commandManager.CollectInput();

            // Configure the robot's settings
            var robot = new Robot(
                commandModel,
                new Map(cordRange, cordRange),
                new MovementTracker(commandModel.StartingPosition));

            // Run robot commands and print report
            robot.RunCommands();
            robot.PrintCleaningReport();
        }
    }
}
