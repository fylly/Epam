using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBusinessLayer.CSVParser
{
    public static class CSVParser
    {
        public static IEnumerable<ParseItem> Parse(List<String> item)
        {
            if (item != null)
            {
                foreach(var i in item)
                {
                    var buff = CSVLineParse.ParseLine(i);
                    if (buff != null)
                    {
                        yield return buff;
                    }
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}
