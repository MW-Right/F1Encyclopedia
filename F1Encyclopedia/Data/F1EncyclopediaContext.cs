using Microsoft.EntityFrameworkCore;
using F1Encyclopedia;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Models.Drivers;
using Data.Models.ConstructorTeams;
using System.Reflection;

namespace Data
{
    public partial class F1EncyclopediaContext : DbContext
    {
        public virtual DbSet<DriverInformation> Drivers { get; set; }
        public virtual DbSet<Constructor> Constructors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
