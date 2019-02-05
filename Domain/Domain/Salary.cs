using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Salary : EntityBase
    {
        public int WorkingHours { get; set; }
        public int SalaryPerHour { get; set; }

        public virtual Employee Employee { get; set; }

        public Salary()
        {

        }

        public Salary(int workingHours, int salaryPerHour)
        {
            if (workingHours <= 0)
                throw new ArgumentException($"{nameof(workingHours)} is not positive");
            if (salaryPerHour <= 0)
                throw new ArgumentException($"{nameof(salaryPerHour)} is not positive");

            this.WorkingHours = workingHours;
            this.SalaryPerHour = salaryPerHour;
        }

        public Salary(long id, int workingHours, int salaryPerHour)
        {
            if (workingHours <= 0)
                throw new ArgumentException($"{nameof(workingHours)} is not positive");
            if (salaryPerHour <= 0)
                throw new ArgumentException($"{nameof(salaryPerHour)} is not positive");

            this.Id = id;
            this.WorkingHours = workingHours;
            this.SalaryPerHour = salaryPerHour;
        }
    }
}
