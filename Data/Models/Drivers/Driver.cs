using Infrastructure.Data.Models.Common;

namespace Infrastructure.Data.Models.Drivers
{
    class Driver
    {
        public int DriverId { get; private set; }
        public string Name { get; set; }
        public bool DaddysCash { get; set; }
        public int Pace { get; set; }
        public int Experience { get; set; }
        public int Racecraft { get; set; }
        public int Awareness { get; set; }

        public Nationality Nationality { get; set; }
        public DriverRating DriverRating { get; set; }
    }
}
