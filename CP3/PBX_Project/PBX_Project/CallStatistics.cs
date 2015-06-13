using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class CallStatistics
    {
        private ICollection<CallStatisticsItem> _callStatistics = new List<CallStatisticsItem>();
        
        public void AddItem(CallStatisticsItem item)
        {
            _callStatistics.Add(item);
        }

        public IEnumerable<CallStatisticsItem> GetStatistics()
        {
            return _callStatistics;
        }
    }
}
