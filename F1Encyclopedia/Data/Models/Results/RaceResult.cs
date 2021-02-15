using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Models.ConstructorTeams;
using System;


namespace F1Encyclopedia.Data.Models.Results
{
    public class RaceResult
    {
        public int Id { get; set; }
        public int RaceWeekendId { get; set; }
        public RaceWeekend RaceWeekend { get; set; }
        public int DriverId { get; set; }
        public Person Driver { get; set; }
        public int ConstructorId { get; set; }    
        public Constructor Constructor { get; set; }
        public int GridPosition { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }
        public int Laps { get; set; }
        public Int64 TimeMillis { get; set; }
        public TimeSpan Time => TimeSpan.FromMilliseconds(TimeMillis);
        public LapTime FastestLap { get; set; }

    }
}
