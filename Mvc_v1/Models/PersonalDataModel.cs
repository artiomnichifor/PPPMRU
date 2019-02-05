using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_v1.Models
{
    public class PersonalDataModel : BaseModel
    {
        [Required(ErrorMessage = "Adress is required")]
        [StringLength(20)]
        public string Adress { get; set; }

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "DoB is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}