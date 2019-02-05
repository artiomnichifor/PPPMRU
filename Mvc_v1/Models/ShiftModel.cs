using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_v1.Models
{
    public class ShiftModel : BaseModel
    {
        [Required(ErrorMessage = "Shift Name is required")]
        [StringLength(20)]
        public string ShiftName { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan BreakTime { get; set; }

    }
}