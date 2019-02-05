using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PersonalDataDto
    {
        public long Id { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }


    }
}
