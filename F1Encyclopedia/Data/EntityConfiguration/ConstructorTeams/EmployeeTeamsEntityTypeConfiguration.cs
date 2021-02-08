using Data.Models.ConstructorTeams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.EntityConfiguration.ConstructorTeams
{
    public class EmployeeTeamsEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeTeam>
    {
        public void Configure(EntityTypeBuilder<EmployeeTeam> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.Employee.Id);
        }
    }
}
