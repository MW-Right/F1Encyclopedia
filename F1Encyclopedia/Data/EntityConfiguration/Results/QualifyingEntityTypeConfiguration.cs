using F1Encyclopedia.Data.Models.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.EntityConfiguration.Results
{
    public class QualifyingEntityTypeConfiguration : IEntityTypeConfiguration<Qualifying>
    {
        public void Configure(EntityTypeBuilder<Qualifying> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Driver)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RaceWeekend)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Constructor)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Position)
                .HasMaxLength(2);
        }
    }
}
