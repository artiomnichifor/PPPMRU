using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_v1.Models
{
    public class DepartmentModel : BaseModel
    {
        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(20)]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Manager Name is required")]
        [StringLength(20)]
        public string ManagerName { get; set; }
    }
}