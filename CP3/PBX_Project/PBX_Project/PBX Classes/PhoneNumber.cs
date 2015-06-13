using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public struct PhoneNumberStruct
    {
        private String _number ;
        public String Number { get { return _number; } }

        public PhoneNumberStruct(String item)
        {
            this._number = item;
        }

        public static bool operator ==(PhoneNumberStruct a, PhoneNumberStruct b)
        {
            return a.Number == b.Number;
        }

        public static bool operator !=(PhoneNumberStruct a, PhoneNumberStruct b)
        {
            return !(a == b);
        }
    }
}
