using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class TariffStandart : IBillingType
    {
        private String _name;
        private double _tariff;

        public TariffStandart(String name,int tariff) 
        {
            _name = name;
            _tariff = tariff;
        }

        public string Name
        {
            get { return _name; }
        }

        public double Tariff
        {
            get { return _tariff; }
        }
    }
}
