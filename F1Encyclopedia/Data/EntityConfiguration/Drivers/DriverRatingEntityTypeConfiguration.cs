using Data.Models.Drivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.EntityConfiguration.Drivers
{
    public class DriverRatingEntityTypeConfiguration : IEntityTypeConfiguration<DriverRating>
    {
        public void Configure(EntityTypeBuilder<DriverRating> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Driver)
                .WithMany(x => x.DriverRatings)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
