using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataAccessLayer.EntityConfiguration
{
    public class EmployeeConfig : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfig()
        {
            Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(20);
            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(30);
            Property(x => x.DateOfEmployment)
                .IsRequired();

            HasKey(x => x.Id);

            HasMany(x => x.Events)
                .WithMany(x => x.Employees)
                .Map(m =>
                {
                    m.ToTable("EmployeesEvents");
                    m.MapLeftKey("EmployeeId");
                    m.MapRightKey("EventId");
                });





            //HasRequired(x => x.Department)
            //    .WithMany(x => x.Employees)
            //    .HasForeignKey(x => x.DepartmentId)
            //    .WillCascadeOnDelete(false);

            //HasRequired(x => x.Salary)
            //    .WithRequiredDependent(x => x.Employee);

            //HasRequired(x => x.PersonalData)
            //    .WithRequiredDependent(x => x.Employee);

            //HasRequired(x => x.Shift)
            //    .WithRequiredPrincipal(x => x.Employee);

        }
    }
}