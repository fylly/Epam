using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSalesSystem.Models
{
    public class ListProductItem
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]        
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required]        
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }
    }

    public class EditProductItem
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 2)]
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }
    }
}