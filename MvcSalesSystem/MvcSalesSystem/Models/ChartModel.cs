using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSalesSystem.Models
{
    public class SalesChartFormModel
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime DateStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Finish Date")]
        public DateTime DateFinish { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateStart < DateFinish)
            {
                yield return new ValidationResult("Finish Date must be greater than Start Date");
            }
        }

    }

    public class SalesChartViewModel
    {
        public IList<Tuple<double, string>> Dates { get; set; }
    }
}