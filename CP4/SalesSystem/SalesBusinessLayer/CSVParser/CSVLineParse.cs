using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBusinessLayer.CSVParser
{
    static class CSVLineParse
    {
        public static ParseItem ParseLine(String item)
        {
            var buffItem = item.Split(new char [] {'='});
            var result = new ParseItem();
            if (buffItem.Count() == 6)
            {
                result.SaleDate = Convert.ToDateTime(buffItem[0]);
                result.CustomerName = buffItem[1];
                result.ProductName = buffItem[2];
                result.Barcode = buffItem[3];
                result.SaleSum = Convert.ToDouble(buffItem[4]);
                result.ManagerName = buffItem[5];
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
