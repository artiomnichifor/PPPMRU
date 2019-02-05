using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Department : EntityBase
    {
        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public Department()
        {

        }

        public Department(string departmentName, string managerName)
        {
            if (string.IsNullOrWhiteSpace(departmentName))
                throw new ArgumentException($"{nameof(departmentName)} is null or empty");
            if (string.IsNullOrWhiteSpace(managerName))
                throw new ArgumentException($"{nameof(managerName)} is null or empty");

            this.DepartmentName = departmentName;
            this.ManagerName = managerName;
        }
    }
}