using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_v1.Models
{
    public class EventModel : BaseModel
    {
        [Required(ErrorMessage = "Event Name is required")]
        [StringLength(20)]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "DoE is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        [StringLength(255)]
        [Display(Name = "Subject")]
        public string Subject { get; set; }
    }
}