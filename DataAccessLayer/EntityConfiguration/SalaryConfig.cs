using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace DataAccessLayer.EntityConfiguration
{
    class SalaryConfig : EntityTypeConfiguration<Salary>
    {
        public SalaryConfig()
        {
            Property(x => x.SalaryPerHour)
                .IsRequired();
            Property(x => x.WorkingHours)
                .IsRequired();

            HasKey(x => x.Id);

            HasRequired(x => x.Employee)
                .WithRequiredDependent(x => x.Salary);
        }


    }
}
