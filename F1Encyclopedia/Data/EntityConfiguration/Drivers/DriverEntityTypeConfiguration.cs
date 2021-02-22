using F1Encyclopedia.Data.Models.Drivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1Encyclopedia.Data.EntityConfiguration.Common
{
    public class DriverEntityTypeConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.Country)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

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
