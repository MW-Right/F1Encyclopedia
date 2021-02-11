using F1Encyclopedia.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.EntityConfiguration.Common
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.DriverInformation)
                .WithOne()
                .HasForeignKey<Person>(x => x.DriverInformationId);

            builder.HasOne(x => x.Country)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
