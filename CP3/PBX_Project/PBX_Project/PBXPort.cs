using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace PBX_Project
{
    public class PBXPort
    {
        private PBXUser _pbxUser;
        private PBXTerminal _pbxTerminal;
        private PortState _state;

        public PhoneNumber phoneNumber { get; set; }

        public PortState State {
            get
            {
                return _state;
            }
        }

        public PBXUser PbxUser {
            get { return _pbxUser; }
            set
            {
                if (value != null)
                {
                    _pbxUser = value;
                }
            }
        }

        public PBXTerminal PbxTerminal { 
            get { return _pbxTerminal; }
            set
            {
                if (value != null)
                {
                    _pbxTerminal = value;
                    _pbxTerminal.Calling += c_Calling;
                    _pbxTerminal.EndedCall += c_EndedCall;
                }
            }
        }
        
         // Constructor
        public PBXPort()
        {
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
        void c_Calling(object sender, CallingEventArgs e)
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

        void c_EndedCall(object sender, CallingEventArgs e)
        {
            if (State != PortState.Disabled)
            {
                EndedCall(this,new PortConnectingToEventArgs());
                _state = PortState.Available;
            }
        }

        // Events
        public event EventHandler<PortConnectingToEventArgs> ConnectingTo;
        public event EventHandler<PortConnectingToEventArgs> EndedCall;
    }
}
