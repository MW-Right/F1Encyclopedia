using Microsoft.EntityFrameworkCore;
using System.Reflection;
using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Models.Tracks;
using F1Encyclopedia.Data.Models.ConstructorTeams;
using F1Encyclopedia.Data.Models.Drivers;

namespace F1Encyclopedia.Data
{
    public partial class F1EncyclopediaContext : DbContext
    {
        public F1EncyclopediaContext() { }
        public F1EncyclopediaContext(DbContextOptions<F1EncyclopediaContext> options) : base(options) { }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<RaceWeekend> RaceWeekends { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Constructor> Constructors { get; set; }
        public virtual DbSet<PersonRole> PersonRoles { get; set; }
        public virtual DbSet<DriverInformation> DriverInformations { get; set; }
        public virtual DbSet<DriverRating> DriverRatings { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RVN5OTQ;Database=F1Encyclopedia;Trusted_Connection=True;");
        }
    }
}
