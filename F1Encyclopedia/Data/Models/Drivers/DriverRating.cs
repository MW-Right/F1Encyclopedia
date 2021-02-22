using F1Encyclopedia.Data.Models.Common;

namespace F1Encyclopedia.Data.Models.Drivers
{
    public class DriverRating
    {
        public int Id { get; private set; }

        public int PersonId { get; set; }
        public Driver Driver { get; set; }
        
        public int RaceWeekendId { get; set; }
        public RaceWeekend RaceWeekend { get; set; }

        public float Rating { get; set; }

    }
}
