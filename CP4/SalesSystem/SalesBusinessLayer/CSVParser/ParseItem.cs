using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBusinessLayer.CSVParser
{
    public class ParseItem
    {
        public System.DateTime SaleDate { get; set; }
        
        public String CustomerName { get; set; }
        
        public String ProductName { get; set; }
        public String Barcode { get; set; }

        public double SaleSum { get; set; }

        public String ManagerName { get; set; }
    }
}
