using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class PBX
    {
        private ICollection<PBXPort> _pbxPorts = new List <PBXPort> ();
        private ActiveRingsCollection _activeRings = new ActiveRingsCollection();

        public void AddPort(PBXPort item)
        {
            _pbxPorts.Add(item);
            _pbxPorts.Last().ConnectingTo += ConnectingToHandler;
            _pbxPorts.Last().EndedCall += EndedCallHandler;
        }
        
        public IEnumerable <PBXPort> GetPorts()
        {
            return _pbxPorts;
        }

        public IEnumerable<ActiveRing> GetActiveRings()
        {
            return _activeRings;
        }

        public void Call(PhoneNumberStruct phoneSource, PhoneNumberStruct phoneDestination)
        {
            var source = _pbxPorts.FirstOrDefault(x => x.PhoneNumber == phoneSource);
            if (source != null)
            {
                source.PbxTerminal.CallTo(phoneDestination);
            }
        }

        public void EndCall(PhoneNumberStruct number)
        {
            var source = _pbxPorts.FirstOrDefault(x => x.PhoneNumber == number);
            if (source != null)
            {
                source.PbxTerminal.EndCall();
            }
        }

        public void UnPlugTerminal(PhoneNumberStruct number)
        {
            var source = _pbxPorts.FirstOrDefault(x => x.PhoneNumber == number);
            if (source != null)
            {
                source.PbxTerminal.UnPlug();
            }
        }

        public void PlugTerminal(PhoneNumberStruct number)
        {
            var source = _pbxPorts.FirstOrDefault(x => x.PhoneNumber == number);
            if (source != null)
            {
                source.PbxTerminal.Plug();
            }
        }

        // Technical Methods
        #region TechnicalMethods
        private bool Connecting(PhoneNumberStruct number)
        {
            var portDestination = _pbxPorts.FirstOrDefault(x => x.PhoneNumber == number);

            if (portDestination != null)
            {
                return portDestination.Ring();
            }
            else
            {
                return false;
            }
        }

        private void Disconnect(PhoneNumberStruct number)
        {
            var portBuff = _pbxPorts.FirstOrDefault(x => x.PhoneNumber == number);
            if (portBuff != null)
            {
                portBuff.Disconnect();
            }
        }
        #endregion

        // EventHandler Methods
        #region EventHandlerMethods
        void ConnectingToHandler(object sender, PortConnectingToEventArgs e)
        {
            if (sender != null && e != null && sender is PBXPort)
            {
                if (Connecting(e.PhoneNumberArg))
                {
                    var firstNumber = ((PBXPort) sender).PhoneNumber;

                    e.PortStateArg = PortState.Busy;
                    e.TerminalStateArg = TerminalState.Busy;

                    _activeRings.Add(new ActiveRing(
                        firstNumber,
                        e.PhoneNumberArg));
                };
            }

        }

        void EndedCallHandler(object sender, PortConnectingToEventArgs e)
        {
            if (sender != null && e != null && sender is PBXPort)
            {
                var firstNumber = ((PBXPort) sender).PhoneNumber;
                var secondNumber = _activeRings.GetSecondNumberByNumber(firstNumber);
                Disconnect(secondNumber);
                _activeRings.DeleteByPhoneNumber(firstNumber);
            }
            
        }
        #endregion
    }
}
