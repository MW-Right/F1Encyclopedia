using F1Encyclopedia.Data.Models.ConstructorTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1Encyclopedia.Data.EntityConfiguration.ConstructorTeams
{
    public class ConstructorEntityTypeConfiguration : IEntityTypeConfiguration<Constructor>
    {
        public void Configure(EntityTypeBuilder<Constructor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Country)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.TeamColours)
                .WithOne(x => x.Constructor)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Staff)
                .WithOne(x => x.Constructor)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
