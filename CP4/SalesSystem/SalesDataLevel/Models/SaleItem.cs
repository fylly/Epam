using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesDataLevel.Models
{
    public class SaleItem
    {
        public int Id { get; set; }
        public string SaleDate { get; set; }
        public double SaleSum { get; set; }

        public virtual Customer Client { get; set; }
        public virtual Product Good { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual InputFile InputFile { get; set; }
    }
}
