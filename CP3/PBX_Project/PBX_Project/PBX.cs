using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class PBX : ICollection<PBXPort>
    {
        private ICollection<PBXPort> _pbxPorts = new List <PBXPort> ();
        private ActiveRingsCollection _activeRings = new ActiveRingsCollection();

        public void Add(PBXPort item)
        {
            _pbxPorts.Add(item);
            _pbxPorts.Last().ConnectingTo += c_ConnectingTo;
            _pbxPorts.Last().EndedCall += c_EndedCall;
        }

        public void Clear()
        {
            _pbxPorts.Clear();
        }

        public bool Contains(PBXPort item)
        {
            return _pbxPorts.Contains(item);
        }

        public void CopyTo(PBXPort[] array, int arrayIndex)
        {
            _pbxPorts.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _pbxPorts.Count; }
        }

        public bool IsReadOnly
        {
            get { return _pbxPorts.IsReadOnly; }
        }

        public bool Remove(PBXPort item)
        {
            return _pbxPorts.Remove(item);
        }

        public IEnumerator<PBXPort> GetEnumerator()
        {
            return _pbxPorts.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Call(PhoneNumber phoneSource, PhoneNumber phoneDestination)
        {
            var source = _pbxPorts.Where(x => x.phoneNumber.Number == phoneSource.Number).ToList();
            if (source.Count > 0)
            {
                source.First().PbxTerminal.CallTo(phoneDestination);
            }
        }

        public void EndCall(PhoneNumber item)
        {
            var source = _pbxPorts.Where(x => x.phoneNumber.Number == item.Number).ToList();
            if (source.Count > 0)
            {
                source.First().PbxTerminal.EndCall();
            }
        }

        public void UnPlugTerminal(PhoneNumber item)
        {
            var source = _pbxPorts.Where(x => x.phoneNumber.Number == item.Number).ToList();
            if (source.Count > 0)
            {
                source.First().PbxTerminal.UnPlug();
            }
        }

        public void PlugTerminal(PhoneNumber item)
        {
            var source = _pbxPorts.Where(x => x.phoneNumber.Number == item.Number).ToList();
            if (source.Count > 0)
            {
                source.First().PbxTerminal.Plug();
            }
        }

        private bool Connecting(PhoneNumber number)
        {
            var portDestination = _pbxPorts.Where(x => x.phoneNumber.Number == number.Number).ToList();

            if (portDestination.Count > 0)
            {
                return portDestination.First().Ring();
            }
            else
            {
                return false;
            }
        }

        private void Disconnect(PhoneNumber item)
        {
            var secondNumber = _activeRings.GetSecondNumber(item);

            var portBuff = _pbxPorts.Where(x => x.phoneNumber.Number == secondNumber.Number).ToList();
            if (portBuff.Count > 0)
            {
                portBuff.First().Disconnect();
            }
        }


        void c_ConnectingTo(object sender, PortConnectingToEventArgs e)
        {
            if (sender != null && e != null)
            {
                if (Connecting(e.PhoneNumberArg))
                {
                    e.PortStateArg = PortState.Busy;
                    e.TerminalStateArg = TerminalState.Busy;

                    if (sender is PBXPort)
                    {
                        _activeRings.Add(new ActiveRing(
                            ((PBXPort) sender).phoneNumber,
                            e.PhoneNumberArg));
                    }
                };
            }

        }

        void c_EndedCall(object sender, PortConnectingToEventArgs e)
        {
            if (sender != null)
            {
                Disconnect(((PBXPort)sender).phoneNumber);
            }
        }
    }
}
