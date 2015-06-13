using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class Client
    {
        public PhoneNumberStruct PhoneNumber { get; set; }
        public String UserName { get; set; }
        public IBillingType BillingType { get; set; }

        public Client(PhoneNumberStruct phoneNumber, String userName, IBillingType billingType)
        {
            PhoneNumber = phoneNumber;
            UserName = userName;
            BillingType = billingType;
        }
    }
}
