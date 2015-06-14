using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class Client
    {
        private PhoneNumberStruct _phoneNumber;
        private String _userName; 
        private IBillingType _billingType; 
        private DateTime _billingChangeDate;

        public PhoneNumberStruct PhoneNumber { get { return _phoneNumber; } }
        public String UserName { get { return _userName; } }
        public IBillingType BillingType { get { return _billingType; } }

        public Client(PhoneNumberStruct phoneNumber, String userName, IBillingType billingType, DateTime billingChangeDate)
        {
            _phoneNumber = phoneNumber;
            _userName = userName;
            _billingType = billingType;
            _billingChangeDate = billingChangeDate;
        }

        public void SetNewBillingType(IBillingType billingType, DateTime billingChangeDate)
        {
            if (billingType != null)
            {
                if ((billingChangeDate - _billingChangeDate).TotalDays > 30)
                {
                    _billingType = billingType;
                    _billingChangeDate = billingChangeDate;
                }
            }
        }
    }
}
