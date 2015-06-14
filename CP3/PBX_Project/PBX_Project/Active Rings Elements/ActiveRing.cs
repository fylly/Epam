using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class ActiveRing
    {
        private PhoneNumberStruct _phoneSource;
        private PhoneNumberStruct _phoneDestination;
        private ActiveRingState _state;
        private DateTime _ringTime;

        public ActiveRing(PhoneNumberStruct source, PhoneNumberStruct destination, DateTime ringTime)
        {
            _phoneSource = source;
            _phoneDestination = destination;
            _ringTime = ringTime;
            _state = ActiveRingState.Ring;
        }

        public PhoneNumberStruct PhoneSource 
        { 
            get { return _phoneSource; } 
        }

        public PhoneNumberStruct PhoneDestination
        {
            get { return _phoneDestination; }
        } 

        public ActiveRingState State
        {
            set { _state = value; }
            get { return _state; }
        }

        public DateTime RingTime
        {
            set { _ringTime = value; }
            get { return _ringTime; }
        }

        // Methods
        public bool IsContainsPhoneNumber(PhoneNumberStruct item)
        {
            if(PhoneSource == item || PhoneDestination == item )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public PhoneNumberStruct GetSecondValueIfExist(PhoneNumberStruct item)
        {
            if (PhoneSource == item)
            {
                return PhoneDestination;
            }
            else
            {
                if (PhoneDestination == item)
                {
                    return PhoneSource;
                }
                else
                {
                    return new PhoneNumberStruct();
                }
            }
        }

        public void SetStateAnswer(DateTime item)
        {
            _state = ActiveRingState.Talk;
            _ringTime = item;
        }
    

    }
}
