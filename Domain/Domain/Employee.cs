using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Employee : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfEmployment { get; set; }

        //public string PasswordHash { get; set; }
        private Employee()
        {

        }

        public Employee(string firstName, string lastName, string email, DateTime dateOfEmployment, long departmentId)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException($"{nameof(firstName)} is null or empty");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException($"{nameof(lastName)} is null or empty");
            if (dateOfEmployment == null)
                throw new ArgumentException($"{nameof(dateOfEmployment)} is null");

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.DateOfEmployment = dateOfEmployment;
            this.DepartmentId = departmentId;
        }
        //public Employee(string firstName, string lastName, string email, DateTime dateOfEmployment, Department department)
        //{
        //    if (string.IsNullOrWhiteSpace(firstName))
        //        throw new ArgumentException($"{nameof(firstName)} is null or empty");
        //    if (string.IsNullOrWhiteSpace(lastName))
        //        throw new ArgumentException($"{nameof(lastName)} is null or empty");

        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //    this.Email = email;
        //    this.DateOfEmployment = dateOfEmployment;
        //    this.Department = department;
        //}

        public long DepartmentId { get; set; }
        public long EventId { get; set; }

        public virtual User User { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual PersonalData PersonalData { get; set; }
        public virtual Department Department { get; set; }
        public virtual Salary Salary { get; set; }
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}