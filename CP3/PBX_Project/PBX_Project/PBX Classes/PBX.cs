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
        private BillingSystem _billingSystem = new BillingSystem();

        public void AddPort(PBXPort item, String name, IBillingType billing )
        {
            _pbxPorts.Add(item);
            _pbxPorts.Last().ConnectingTo += ConnectingToHandler;
            _pbxPorts.Last().EndedCall += EndedCallHandler;
            _pbxPorts.Last().Answered += AnsweredHandler;

            _billingSystem.AddClient(new Client(item.PhoneNumber, name, billing, System.DateTime.Now));
        }

        // Methods For Statistics: Billing, ActiveRings, Ports
        #region MethodsForStatistics
        public IEnumerable <PBXPort> GetPorts()
        {
            return _pbxPorts;
        }

        public IEnumerable<ActiveRing> GetActiveRings()
        {
            return _activeRings;
        }

        public IEnumerable<CallStatisticsItem> GetStatistics()
        {
            return _billingSystem.GetStatistics();
        }

        public IEnumerable<CallStatisticsItem> GetStatisticsByNumber(PhoneNumberStruct number)
        {
            return _billingSystem.GetStatisticsByNumber(number);
        }
        #endregion

        // Methods For Terminals : Call, Disconect ...
        #region MethodsForTerminals
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

        public void Answer(PhoneNumberStruct number)
        {
            var source = _pbxPorts.FirstOrDefault(x => x.PhoneNumber == number);
            if (source != null)
            {
                source.PbxTerminal.Answer();
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
        #endregion

        #region MethodsForBilling
        public void SetNewBillingType(PhoneNumberStruct number, IBillingType billingType)
        {
            _billingSystem.SetNewBillingType(number,billingType,new DateTime(2016,11,1));
        }
        #endregion

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
            if (sender is PBXPort && e != null )
            {
                var firstNumber = ((PBXPort) sender).PhoneNumber;
                if (firstNumber != e.PhoneNumberArg)
                {
                    if (Connecting(e.PhoneNumberArg))
                    {
                        e.PortStateArg = PortState.Busy;
                        e.TerminalStateArg = TerminalState.Busy;

                        _activeRings.Add(new ActiveRing(
                            firstNumber,
                            e.PhoneNumberArg,
                            System.DateTime.Now));
                    }
                }
            }
        }

        void EndedCallHandler(object sender, PortDefaultEventArgs e)
        {
            if (sender is PBXPort && e != null)
            {
                var firstNumber = ((PBXPort) sender).PhoneNumber;
                var secondNumber = _activeRings.GetSecondNumberByNumber(firstNumber);
                Disconnect(secondNumber);
                
                var activeRing = _activeRings.GetActiveTalkByNumber(firstNumber);
                if (activeRing != null)
                {
                    _billingSystem.AddCallStatistics(activeRing.PhoneSource, activeRing.PhoneDestination,activeRing.RingTime, System.DateTime.Now);
                }
                
                _activeRings.DeleteByPhoneNumber(firstNumber);
                
            }
        }

        void AnsweredHandler(object sender, PortDefaultEventArgs e)
        {
            if (sender is PBXPort && e != null)
            {
                if (e.PortStateArg == PortState.Busy && e.TerminalStateArg == TerminalState.Ring)
                {
                    var activeRingBuff = _activeRings.FirstOrDefault(x => x.PhoneDestination == ((PBXPort) sender).PhoneNumber);
                    if (activeRingBuff != null)
                    {
                        activeRingBuff.SetStateAnswer(System.DateTime.Now);
                        e.TerminalStateArg = TerminalState.Busy;
                    }
                    else
                    {
                        e.PortStateArg = PortState.Available;
                        e.TerminalStateArg = TerminalState.Available;
                    }
                }
            }
        }
        #endregion
    }
}
