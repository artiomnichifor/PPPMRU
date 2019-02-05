using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityConfiguration
{
    class ShiftConfig : EntityTypeConfiguration<Shift>
    {
        public ShiftConfig()
        {
            Property(x => x.ShiftName)
                .IsRequired()
                .HasMaxLength(20);
            Property(x => x.StartTime)
                .IsRequired();
            Property(x => x.EndTime)
                .IsRequired();
            Property(x => x.BreakTime)
                .IsRequired();

            HasKey(x => x.Id);

            HasRequired(x => x.Employee)
                .WithRequiredDependent(x => x.Shift);

        }
    }
}
