using Mvc_v1.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_v1.Models
{
    public class SalaryModel : BaseModel
    {
        [Required(ErrorMessage = "WorkinHours are required")]
        [PositiveNumberAtribute]
        public int WorkingHours { get; set; }
        [Required(ErrorMessage = "WorkinHours are required")]
        [PositiveNumberAtribute]
        public int SalaryPerHour { get; set; }
    }
}