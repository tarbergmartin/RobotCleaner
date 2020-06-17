using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleaner.Core
{
    public class CommandModel
    {
        public List<Command> Commands { get; set; }
        public Position StartingPosition { get; set; }
    }
}
