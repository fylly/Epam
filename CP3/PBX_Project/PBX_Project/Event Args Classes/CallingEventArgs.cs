﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class CallingEventArgs : EventArgs
    {
        public TerminalState TerminalStateArg { get; set; }
        public PhoneNumberStruct PhoneNumberArg { get; set; }
    }
}
