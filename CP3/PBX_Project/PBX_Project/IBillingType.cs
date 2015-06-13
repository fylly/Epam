using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public interface IBillingType
    {
        String Name { set; get; }
        int Tariff { set; get; }

    }
}
