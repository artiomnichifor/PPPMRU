using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace DataAccessLayer.EntityConfiguration
{
    class PersonalDataConfig : EntityTypeConfiguration<PersonalData>
    {
        public PersonalDataConfig()
        {
            Property(x => x.Adress)
                .IsRequired()
                .HasMaxLength(40);
            Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);
            Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnName("DoB");
            //.HasColumnType("datetime2");

            HasKey(x => x.Id);

            HasRequired(x => x.Employee)
                .WithRequiredDependent(x => x.PersonalData);

        }
    }
}
