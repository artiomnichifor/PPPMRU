using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Mvc_v1.Validations;


namespace Mvc_v1.Models
{
    public class EmployeeModel : BaseModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(40)]
        [EmailAddress(ErrorMessage ="InvalidAddress")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "DoE is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [PastDate]
        [DataType(DataType.Date)]
        public DateTime DateOfEmployment { get; set; }

        public long DepartmentId { get; set; }
    }
}