using F1Encyclopedia.Data.Models.ConstructorTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1Encyclopedia.Data.EntityConfiguration.ConstructorTeams
{
    public class PersonRoleEntityTypeConfiguration : IEntityTypeConfiguration<PersonRole>
    {
        public void Configure(EntityTypeBuilder<PersonRole> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Teams)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Constructor)
                .WithMany(x => x.Staff)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.From)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.To)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
