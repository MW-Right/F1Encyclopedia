using F1Encyclopedia.Data.Models.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1Encyclopedia.Data.EntityConfiguration.Results
{
    public class RaceResultEntityTypeConfiguration : IEntityTypeConfiguration<RaceResult>
    {
        public void Configure(EntityTypeBuilder<RaceResult> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.RaceWeekend)
                .WithMany()
                .HasForeignKey(x => x.RaceWeekendId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Driver)
                .WithMany()
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Constructor)
                .WithMany()
                .HasForeignKey(x => x.ConstructorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
