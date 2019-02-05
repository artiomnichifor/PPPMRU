using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PersonalData  :EntityBase
    {
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual Employee Employee { get; set; }

        public PersonalData()
        {

        }

        public PersonalData(string adress, string phoneNumber, DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(adress))
                throw new ArgumentException($"{nameof(adress)} is null or empty");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException($"{nameof(phoneNumber)} is null or empty");
            if (dateOfBirth == null)
                throw new ArgumentException($"{nameof(dateOfBirth)} is null");

            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
        }

        public PersonalData(long id, string adress, string phoneNumber, DateTime dateOfBirth)
        {
            this.Id = id;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
        }
    }
}
