using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleaner.Core
{
    public class Command
    {
        public Direction Direction { get; set; }
        public int Steps { get; set; }
    }
}
