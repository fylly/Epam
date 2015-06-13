using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class BillingSystem
    {
        ICollection<Client> _clients = new List<Client>();
        CallStatistics _callStatistics = new CallStatistics();
       
        public void AddCallStatistics(PhoneNumberStruct phoneSource,PhoneNumberStruct phoneDestination, DateTime startTimeCall, DateTime finishTimeCall)
        {
            var user = _clients.FirstOrDefault(x => x.PhoneNumber == phoneSource);
            if (user != null && user.BillingType != null) 
            {
                _callStatistics.AddItem(new CallStatisticsItem(phoneSource, phoneDestination, user.BillingType, startTimeCall, finishTimeCall));
            }           
        }

        public void AddClient (Client item)
        {
            _clients.Add(item);
        }

        public IEnumerable<CallStatisticsItem> GetStatistics ()
        {
            return _callStatistics.GetStatistics();
        }
        
        
    }
}
