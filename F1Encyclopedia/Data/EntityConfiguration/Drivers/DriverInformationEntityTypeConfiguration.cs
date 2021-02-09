using Data.Models.Drivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.EntityConfiguration.Drivers
{
    public class DriverInformationEntityTypeConfiguration : IEntityTypeConfiguration<DriverInformation>
    {
        public void Configure(EntityTypeBuilder<DriverInformation> builder)
        {
            builder.HasKey(x => x.DriverInformationId);

            builder.HasOne(x => x.Driver)
                .WithOne(x => x.DriverInformation)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Number)
                .HasMaxLength(2);

            builder.Property(x => x.Pace)
                .HasMaxLength(2);

            builder.Property(x => x.Experience)
                .HasMaxLength(2);

            builder.Property(x => x.Racecraft)
                .HasMaxLength(2);

            builder.Property(x => x.Awareness)
                .HasMaxLength(2);
        }
    }
}
