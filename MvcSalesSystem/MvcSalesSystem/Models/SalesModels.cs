﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSalesSystem.Models
{
    public class EditSalesItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sale Date")]
        public DateTime SaleDate { get; set; }

        [Required]
        [Display(Name = "Sale Sum")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        [Range(typeof(decimal), "0,01", "9999999999", ErrorMessage = "Введите сумму, в качестве разделителя дробной и целой части используется запятая")]
        public double SaleSum { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int Customer { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int Product { get; set; }

        [Required]
        [Display(Name = "Manager")]
        public int Manager { get; set; }
    }

    public class ListSalesItem
    {
        public int Id;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sale Date")]
        public DateTime SaleDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sale Sum")]
        public double SaleSum { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public string Customer { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string Product { get; set; }

        [Required]
        [Display(Name = "Manager")]
        public string Manager { get; set; }
    }


}