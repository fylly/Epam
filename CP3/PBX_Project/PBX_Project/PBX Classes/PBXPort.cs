using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace PBX_Project
{
    public class PBXPort
    {
        private PBXTerminal _pbxTerminal;
        private PortState _state;

        public PhoneNumberStruct PhoneNumber { get; set; }

        public PortState State {
            get
            {
                return _state;
            }
        }
        
        public PBXTerminal PbxTerminal { 
            get { return _pbxTerminal; }
            set
            {
                if (value != null)
                {
                    _pbxTerminal = value;
                    _pbxTerminal.CallingTo += CallingHandler;
                    _pbxTerminal.EndedCall += EndedCallHandler;
                    _pbxTerminal.Answered += AnsweredHandler;
                }
            }
        }
        
         // Constructor
        public PBXPort(PhoneNumberStruct number)
        {
            PhoneNumber = number;
            _state = PortState.Available;
        }

        // Metods
        public bool Ring()
        {
            if (State == PortState.Available)
            {
                if (_pbxTerminal.Ring())
                {
                    _state = PortState.Busy;
                    OnRinging(new PortDefaultEventArgs());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Disconnect()
        {
            if (State != PortState.Disabled)
            {
               _state = PortState.Available;
                PbxTerminal.Disconnect();
            }
        }

        // Delegates
        #region EventHandlerMethods
        private void CallingHandler(object sender, CallingEventArgs e)
        {
            if (sender is PBXTerminal && e != null)
            {
                if (State == PortState.Available)
                {
                    PortConnectingToEventArgs portConnectingToEventArgs = new PortConnectingToEventArgs();
                    portConnectingToEventArgs.PhoneNumberArg = e.PhoneNumberArg;
                    portConnectingToEventArgs.TerminalStateArg = e.TerminalStateArg;
                    portConnectingToEventArgs.PortStateArg = State;

                    OnConnectingTo(portConnectingToEventArgs);

                    _state = portConnectingToEventArgs.PortStateArg;
                    e.TerminalStateArg = portConnectingToEventArgs.TerminalStateArg;
                }
            }
            
        }

        private void EndedCallHandler(object sender, TerminalDefaultEventArg e)
        {
            if (sender is PBXTerminal && e != null)
            {
                if (State != PortState.Disabled)
                {
                    PortDefaultEventArgs portDefaultEventArgs = new PortDefaultEventArgs();
                    portDefaultEventArgs.TerminalStateArg = e.TerminalStateArg;
                    portDefaultEventArgs.PortStateArg = State;

                    OnEndedCall(portDefaultEventArgs);

                    _state = PortState.Available;
                }
            }
        }

        private void AnsweredHandler(object sender, TerminalDefaultEventArg e)
        {
            if (sender is PBXTerminal && e != null)
            {
                if (State == PortState.Busy)
                {
                    PortDefaultEventArgs portDefaultEventArgs = new PortDefaultEventArgs();
                    portDefaultEventArgs.TerminalStateArg = e.TerminalStateArg;
                    portDefaultEventArgs.PortStateArg = State;

                    OnAnswered(portDefaultEventArgs);

                    _state = portDefaultEventArgs.PortStateArg;
                    e.TerminalStateArg = portDefaultEventArgs.TerminalStateArg;
                }
            }
        }
        #endregion


        #region OnHandlerMethods
        protected virtual void OnConnectingTo(PortConnectingToEventArgs e)
        {
            EventHandler<PortConnectingToEventArgs> handler = ConnectingTo;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnEndedCall(PortDefaultEventArgs e)
        {
            EventHandler<PortDefaultEventArgs> handler = EndedCall;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnRinging(PortDefaultEventArgs e)
        {
            EventHandler<PortDefaultEventArgs> handler = Ringing;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnAnswered(PortDefaultEventArgs e)
        {
            EventHandler<PortDefaultEventArgs> handler = Answered;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        // Events
        public event EventHandler<PortConnectingToEventArgs> ConnectingTo;
        public event EventHandler<PortDefaultEventArgs> EndedCall;
        public event EventHandler<PortDefaultEventArgs> Ringing;
        public event EventHandler<PortDefaultEventArgs> Answered;
    }
}
