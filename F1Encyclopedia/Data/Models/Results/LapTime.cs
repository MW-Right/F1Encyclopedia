using F1Encyclopedia.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Models.Results
{
    public class LapTime
    {
        public int Id { get; set; }
        public int RaceWeekendId { get; set; }
        public RaceWeekend RaceWeekend { get; set; }
        public int DriverId { get; set; }
        public Person Driver { get; set; }
        public int Position { get; set; }
        public long TimeMillis { get; set; }
        public TimeSpan Time => TimeSpan.FromMilliseconds(TimeMillis);
    }
}
