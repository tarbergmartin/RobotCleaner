using System.Collections.Generic;

namespace RobotCleaner.Core
{
    public class CommandModel
    {
        public List<Command> Commands { get; set; }
        public Position StartingPosition { get; set; }
    }
}
