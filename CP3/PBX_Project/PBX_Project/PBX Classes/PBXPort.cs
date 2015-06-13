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
                    //Ringing(this, new PortConnectingToEventArgs());
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
            if (sender != null && e != null && State == PortState.Available)
            {
                PortConnectingToEventArgs portConnectingToEventArgs = new PortConnectingToEventArgs();
                portConnectingToEventArgs.PhoneNumberArg = e.PhoneNumberArg;
                portConnectingToEventArgs.TerminalStateArg = e.TerminalStateArg; 
                portConnectingToEventArgs.PortStateArg = State;

                ConnectingTo(this, portConnectingToEventArgs);

                _state = portConnectingToEventArgs.PortStateArg;
                e.TerminalStateArg = portConnectingToEventArgs.TerminalStateArg;
            }
            
        }

        private void EndedCallHandler(object sender, CallingEventArgs e)
        {
            if (State != PortState.Disabled)
            {
                EndedCall(this,new PortConnectingToEventArgs());
                _state = PortState.Available;
            }
        }
        #endregion

        // Events
        public event EventHandler<PortConnectingToEventArgs> ConnectingTo;
        public event EventHandler<PortConnectingToEventArgs> EndedCall;
        public event EventHandler<PortConnectingToEventArgs> Ringing;
    }
}
