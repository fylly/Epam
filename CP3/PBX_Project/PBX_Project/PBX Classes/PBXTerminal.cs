using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;

namespace PBX_Project
{
    public class PBXTerminal
    {
        private TerminalState _state;

        public TerminalState State
        {
            get
            {
                return _state;
            }
        }

        // Constructor
        public PBXTerminal()
        {
            _state = TerminalState.Available;
        }

        // Users Methods
        #region UsersMethods
        public bool CallTo(PhoneNumberStruct number)
        {
            if (State == TerminalState.Available)
            {
                CallingEventArgs callingEventArgs = new CallingEventArgs();
                callingEventArgs.PhoneNumberArg = number;
                callingEventArgs.TerminalStateArg = TerminalState.Available;

                CallingTo(this, callingEventArgs);

                _state = callingEventArgs.TerminalStateArg;

            }
            return false;
        }

        public void EndCall()
        {
            if (State != TerminalState.Disabled)
            {
                EndedCall(this, new CallingEventArgs());

                _state = TerminalState.Available;
            }
        }

        public void Plug()
        {
            if (_state == TerminalState.Disabled)
            {
                _state = TerminalState.Available;
            }
        }

        public void UnPlug()
        {
            if (_state == TerminalState.Available)
            {
                _state = TerminalState.Disabled;
            }
        }
        #endregion

        // Technical Methods
        #region UsersMethods
        public bool Ring()
        {
            if (State == TerminalState.Available)
            {
                _state = TerminalState.Ring;
                //Ringing(this, new CallingEventArgs());
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Disconnect()
        {
            if (State != TerminalState.Disabled)
            {
                _state = TerminalState.Available;
            }
        }
        #endregion

        public event EventHandler<CallingEventArgs> CallingTo;
        public event EventHandler<CallingEventArgs> EndedCall;
        public event EventHandler<CallingEventArgs> Ringing;

    }
}
