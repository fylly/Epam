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

        public ActiveRing(PhoneNumberStruct source, PhoneNumberStruct destination)
        {
            _phoneSource = source;
            _phoneDestination = destination;
            _state = ActiveRingState.Ring;
        }

        public PhoneNumberStruct PhoneSource 
        { 
            get
            {  
                return _phoneSource; 
            } 
        }

        public PhoneNumberStruct PhoneDestination
        {
            get
            {
                return _phoneDestination;
            }
        } 

        public ActiveRingState State
        {
            get
            {
                return _state;
            }
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
            else if(PhoneDestination == item)
            {
                return PhoneSource;
            }
            else
            {
                return new PhoneNumberStruct();
            }
        }    
    }
}
