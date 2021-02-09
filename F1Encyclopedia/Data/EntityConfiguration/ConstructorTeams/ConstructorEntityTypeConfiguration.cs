using Data.Models.ConstructorTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.EntityConfiguration.ConstructorTeams
{
    public class ConstructorEntityTypeConfiguration : IEntityTypeConfiguration<Constructor>
    {
        public void Configure(EntityTypeBuilder<Constructor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Country);

            builder.HasMany(x => x.TeamColours)
                .WithOne(x => x.Constructor);

            builder.HasMany(x => x.Staff)
                .WithOne(x => x.Constructor);
        }
    }
}
