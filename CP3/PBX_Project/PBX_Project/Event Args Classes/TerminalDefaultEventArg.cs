using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class TerminalDefaultEventArg : EventArgs
    {
        public TerminalState TerminalStateArg { get; set; }
    }
}
