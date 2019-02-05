using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataAccessLayer.EntityConfiguration
{
    public class DepartmentConfig : EntityTypeConfiguration<Department>
    {
        public DepartmentConfig()
        {
            Property(x => x.DepartmentName)
                .IsRequired()
                .HasMaxLength(20);
            Property(x => x.ManagerName)
                .IsRequired()
                .HasMaxLength(30);

            HasKey(x => x.Id);

            HasMany(x => x.Employees)
                .WithRequired(x => x.Department)
                .HasForeignKey(x => x.DepartmentId)
                .WillCascadeOnDelete(false);

        }
    }
}