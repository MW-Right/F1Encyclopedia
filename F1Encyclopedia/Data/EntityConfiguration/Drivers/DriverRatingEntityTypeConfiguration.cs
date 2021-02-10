using F1Encyclopedia.Data.Models.Drivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
