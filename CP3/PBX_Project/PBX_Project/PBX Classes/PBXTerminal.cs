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
            get { return _state; }
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

                OnCallingTo(callingEventArgs);

                _state = callingEventArgs.TerminalStateArg;

            }
            return false;
        }

        public void EndCall()
        {
            if (State != TerminalState.Disabled)
            {
                TerminalDefaultEventArg terminalDefaultEventArg = new TerminalDefaultEventArg();
                terminalDefaultEventArg.TerminalStateArg = _state;

                OnEndedCall(terminalDefaultEventArg);

                _state = TerminalState.Available;
            }
        }

        public void Answer()
        {
            if (State == TerminalState.Ring)
            {
                TerminalDefaultEventArg terminalDefaultEventArg = new TerminalDefaultEventArg();
                terminalDefaultEventArg.TerminalStateArg = _state;

                OnAnswered(terminalDefaultEventArg);

                _state = terminalDefaultEventArg.TerminalStateArg;
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

                OnRinging(new TerminalDefaultEventArg());

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


        #region OnHandlerMethods
        protected virtual void OnCallingTo(CallingEventArgs e)
        {
            EventHandler<CallingEventArgs> handler = CallingTo;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnEndedCall(TerminalDefaultEventArg e)
        {
            EventHandler<TerminalDefaultEventArg> handler = EndedCall;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnRinging(TerminalDefaultEventArg e)
        {
            EventHandler<TerminalDefaultEventArg> handler = Ringing;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnAnswered(TerminalDefaultEventArg e)
        {
            
            EventHandler<TerminalDefaultEventArg> handler = Answered;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        public event EventHandler<CallingEventArgs> CallingTo;
        public event EventHandler<TerminalDefaultEventArg> EndedCall;
        public event EventHandler<TerminalDefaultEventArg> Ringing;
        public event EventHandler<TerminalDefaultEventArg> Answered;

    }
}
