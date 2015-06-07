using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class PBXTerminal
    {
        public TerminalState State { get; set; }

        public void CallTo(String number)
        {
            if (State == TerminalState.Available)
            {
                CallingEventArgs callingEventArgs = new CallingEventArgs();
                callingEventArgs.PhoneNumberArg = new PhoneNumber() { Number = number };
                callingEventArgs.TerminalStateArg = TerminalState.Available;

                Calling(this, callingEventArgs);
            }
            
        }

        public void Reset()
        {
            if (State != TerminalState.Disabled)
            {
                CallingEventArgs callingEventArgs = new CallingEventArgs();
                Resetting(this, callingEventArgs);

                State = TerminalState.Available;
            }
        }
        
        public event EventHandler<CallingEventArgs> Calling;
        public event EventHandler<CallingEventArgs> Resetting;
    }
}
