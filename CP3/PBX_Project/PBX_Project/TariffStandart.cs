using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class TariffStandart : IBillingType
    {
        private String _name;
        private int _tariff;

        public TariffStandart(String name,int tariff) 
        {
            Name = name;
            Tariff = tariff;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Tariff
        {
            get { return _tariff; }
            set { _tariff = value; }
        }
    }
}
