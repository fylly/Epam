using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSalesSystem.Models
{
    public class ListCustomerItem
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }
    }

    public class EditCustomerItem
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }
    }
}