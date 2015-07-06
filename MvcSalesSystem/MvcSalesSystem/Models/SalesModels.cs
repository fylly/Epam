using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSalesSystem.Models
{
    public class EditSalesItem
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sale Date")]
        public DateTime SaleDate { get; set; }

        public double SaleSum { get; set; }

        public string Customer { get; set; }
        public string Product { get; set; }
        public string Manager { get; set; }
        public string InputFile { get; set; }
    }
}