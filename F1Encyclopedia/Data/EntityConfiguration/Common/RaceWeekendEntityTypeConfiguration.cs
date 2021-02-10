using F1Encyclopedia.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
