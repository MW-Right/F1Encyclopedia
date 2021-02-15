using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Models.ConstructorTeams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Models.Results
{
    public class Qualifying
    {
        public int Id { get; set; }
        public int RaceWeekendId { get; set; }
        public RaceWeekend RaceWeekend { get; set; }

        public int DriverId { get; set; }
        public Person Driver { get; set; }

        public int ConstructorId { get; set; }
        public Constructor Constructor { get; set; }
        public int Position { get; set; }
        public DateTime? Q1 { get; set; }
        public DateTime? Q2 { get; set;}
        public DateTime? Q3 { get; set; }
    }
}
