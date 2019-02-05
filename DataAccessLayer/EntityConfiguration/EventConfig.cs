using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace DataAccessLayer.EntityConfiguration
{
    class EventConfig : EntityTypeConfiguration<Event>
    {
        public EventConfig()
        {
            Property(x => x.EventName)
                .IsRequired()
                .HasMaxLength(20);
            Property(x => x.EventDate)
                .IsRequired()
                .HasColumnType("datetime2");
            Property(x => x.StartTime)
                .IsRequired();
            Property(x => x.EndTime)
                .IsRequired();
            Property(x => x.Subject)
                .IsRequired()
                .HasMaxLength(250);

            HasKey(x => x.Id);
        }
    }
}
