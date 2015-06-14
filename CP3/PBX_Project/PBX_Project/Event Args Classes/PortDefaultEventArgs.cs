using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class PortDefaultEventArgs : EventArgs
    {
        public TerminalState TerminalStateArg { get; set; }
        public PortState PortStateArg { get; set; }
    }
}
