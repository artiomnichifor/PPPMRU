using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DepartmentDto
    {
        public long Id { get; set; }
        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}
