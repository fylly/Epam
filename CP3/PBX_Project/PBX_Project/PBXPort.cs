using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class PBXPort
    {
        private PBXUser _pbxUser;
        private PBXTerminal _pbxTerminal;

        public PortState State { get; set; }

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
                    _pbxTerminal.Resetting += c_Resetting;
                }
            }
        }
        
        void c_Calling(object sender, CallingEventArgs e)
        {
            Console.WriteLine("1111");
        }

        void c_Resetting(object sender, CallingEventArgs e)
        {
            if (State != PortState.Disabled)
            {
                State = PortState.Available;
            }
        }

    }
}
