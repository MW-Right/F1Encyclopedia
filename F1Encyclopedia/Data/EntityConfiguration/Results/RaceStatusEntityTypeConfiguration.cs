using F1Encyclopedia.Data.Models.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1Encyclopedia.Data.EntityConfiguration.Results
{
    public class RaceStatusEntityTypeConfiguration : IEntityTypeConfiguration<RaceStatus>
    {
        public void Configure(EntityTypeBuilder<RaceStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .HasMaxLength(50);
        }
    }
}
