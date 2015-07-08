﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSalesSystem.Models
{
    public class ListProductItem
    {

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
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }
    }
}