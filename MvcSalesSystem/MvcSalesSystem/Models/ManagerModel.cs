using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSalesSystem.Models
{
    public class ListManagerItem
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ManagerName { get; set; }
    }

    public class EditManagerItem
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 1)]
        [Display(Name = "Name")]
        public string ManagerName { get; set; }
    }
}