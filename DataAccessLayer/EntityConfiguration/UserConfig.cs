using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataAccessLayer.EntityConfiguration
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(40);
            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(40);
            Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(30);

            HasKey(x => x.Id);

           HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.ToTable("UserRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });

            HasRequired(x => x.Employee)
                .WithRequiredDependent(x => x.User);

        }
    }
}
