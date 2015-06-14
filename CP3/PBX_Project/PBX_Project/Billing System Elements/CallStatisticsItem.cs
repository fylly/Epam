using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class CallStatisticsItem
    {
        private PhoneNumberStruct _phoneSource;
        private PhoneNumberStruct _phoneDestination;
        private IBillingType _billingType;
        private DateTime _startTimeCall;
        private DateTime _finishTimeCall;

        public CallStatisticsItem(PhoneNumberStruct phoneSource, PhoneNumberStruct phoneDestination, IBillingType billingType, DateTime startTimeCall, DateTime finishTimeCall)
        {
            _phoneSource = phoneSource;
            _phoneDestination = phoneDestination;
            _billingType = billingType;
            _startTimeCall = startTimeCall;
            _finishTimeCall = finishTimeCall;
        }

        public PhoneNumberStruct PhoneSource
        {
            get { return _phoneSource; }
        }

        public PhoneNumberStruct PhoneDestination
        {
            get { return _phoneDestination; }
        }

        public IBillingType BillingType
        {
            get { return _billingType; }
        }

        public DateTime StartTimeCall
        {
            get { return _startTimeCall; }
        }

        public DateTime FinishTimeCall
        {
            get { return _finishTimeCall; }
        }

        public TimeSpan TimeCall
        {
            get { return (FinishTimeCall - StartTimeCall); }
        }

        public double Summ
        {
            get
            {
                if (BillingType != null)
                { return Math.Truncate(TimeCall.TotalSeconds) * BillingType.Tariff; }
                else
                { return 0; }
            }
        }
    }
}
