using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class SalaryDto
    {
        public long Id { get; set; }
        public int WorkingHours { get; set; }
        public int SalaryPerHour { get; set; }
    }
}
