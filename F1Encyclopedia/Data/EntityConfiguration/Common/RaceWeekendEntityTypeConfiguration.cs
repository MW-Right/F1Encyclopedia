using Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.EntityConfiguration.Common
{
    public class RaceWeekendEntityTypeConfiguration : IEntityTypeConfiguration<RaceWeekend>
    {
        public void Configure(EntityTypeBuilder<RaceWeekend> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Year)
                .HasMaxLength(2);
        }
    }
}
