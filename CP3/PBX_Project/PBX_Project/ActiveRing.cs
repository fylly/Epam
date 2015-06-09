using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class ActiveRing
    {
        private PhoneNumber _phoneSource;
        private PhoneNumber _phoneDestination;
        private TerminalState _state;

        public ActiveRing (PhoneNumber source, PhoneNumber destination)
        {
            _phoneSource = source;
            _phoneDestination = destination;
            _state = TerminalState.Ring;
        }

        public PhoneNumber PhoneSource 
        { 
            get
            {  
                return _phoneSource; 
            } 
        } 

        public PhoneNumber PhoneDestination
        {
            get
            {
                return _phoneDestination;
            }
        } 

        public TerminalState State
        {
            get
            {
                return _state;
            }
        }

        // Methods
        public bool IsContainsPhoneNumber(PhoneNumber item)
        {
            if(PhoneSource.Number == item.Number || PhoneDestination.Number == item.Number )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public PhoneNumber GetSecondValueIfExist(PhoneNumber item)
        {
            if (PhoneSource.Number == item.Number)
            {
                return PhoneDestination;
            }
            else if(PhoneDestination.Number == item.Number)
            {
                return PhoneSource;
            }
            else
            {
                return new PhoneNumber();
            }
        }    
    }
}
