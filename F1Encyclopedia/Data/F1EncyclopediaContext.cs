using Microsoft.EntityFrameworkCore;
using System.Reflection;
using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Models.Tracks;
using F1Encyclopedia.Data.Models.ConstructorTeams;
using F1Encyclopedia.Data.Models.Drivers;
using System.Threading.Tasks;
using System;
using System.Linq;
using F1Encyclopedia.Data.Models.Results;
using JetBrains.Annotations;

namespace F1Encyclopedia.Data
{
    public partial class F1EncyclopediaContext : DbContext
    {
        public F1EncyclopediaContext() { }
        public F1EncyclopediaContext(DbContextOptions<F1EncyclopediaContext> options) : base(options) { }

        // Common
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<RaceWeekend> RaceWeekends { get; set; }
        
        // Constructors
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Constructor> Constructors { get; set; }
        public virtual DbSet<PersonRole> PersonRoles { get; set; }
        
        // Drivers
        public virtual DbSet<DriverInformation> DriverInformations { get; set; }
        public virtual DbSet<DriverRating> DriverRatings { get; set; }
        
        // Tracks
        public virtual DbSet<Track> Tracks { get; set; }
        
        // Results
        public virtual DbSet<RaceStatus> RaceStatuses { get; set; }
        public virtual DbSet<Qualifying> Qualifyings { get; set; }
        public virtual DbSet<RaceResult> RaceResults { get; set; }
        public virtual DbSet<LapTime> LapTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RVN5OTQ;Database=F1Encyclopedia;Trusted_Connection=True;");
        }

        public void CleanTable(string tableName)
        {
            Database.ExecuteSqlRaw(
                $"DELETE FROM {tableName} WHERE 1=1\n" +
                $"DBCC CHECKIDENT ('[{tableName}]', RESEED, 0);");
        }
    }
}
