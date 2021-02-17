using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Models.ConstructorTeams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Models.Results
{
    public class RaceResult
    {
        public int Id { get; set; }
        public int GridPosition { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }
        public int Laps { get; set; }
        public TimeSpan? Time { get; set; }

        public int StatusId { get; set; }
        public RaceStatus Status { get; set; }
        public bool Finished => StatusId == 1;
        public int RaceWeekendId { get; set; }
        public RaceWeekend RaceWeekend { get; set; }
        public int DriverId { get; set; }
        public Person Driver { get; set; }
        public int ConstructorId { get; set; }
        public Constructor Constructor { get; set; }

        public List<LapTime> LapTimes = new List<LapTime>();
        public LapTime FastestLap => LapTimes.OrderBy(x => x.TimeMillis).FirstOrDefault();

        public static RaceResult FromCsv(string line, F1EncyclopediaContext db)
        {
            var values = line.Split(',');

            var raceWeekendId = RaceWeekend.RaceWeekendIdCorrection(values[1]);
            var driverId = Person.DriverIdCorrection(values[2]);
            var constructorId = Constructor.ConstructorIdCorrection(values[3]);
            var statusId = RaceStatus.StatusIdCorrection(values[17]);

            var raceWeekend = db.RaceWeekends.FirstOrDefault(x => x.Id == raceWeekendId);
            var driver = db.Persons.FirstOrDefault(x => x.Id == driverId);
            var constructor = db.Constructors.FirstOrDefault(x => x.Id == constructorId);
            var status = db.RaceStatuses.FirstOrDefault(x => x.Id == statusId);

            LogUnmatchedProperties(raceWeekend, raceWeekendId);
            LogUnmatchedProperties(driver, driverId);
            LogUnmatchedProperties(constructor, constructorId);
            LogUnmatchedProperties(status, statusId);

            var raceResult = new RaceResult()
            {
                GridPosition = Convert.ToInt32(values[5]),
                Position = Convert.ToInt32(values[8]),
                Points = Convert.ToInt32(values[9]),
                Laps = Convert.ToInt32(values[10]),
                Time = GetTimeSpan(values[12]),
                RaceWeekendId = raceWeekend != null ? raceWeekend.Id : 1,
                DriverId = driver != null ? driver.Id : 1,
                ConstructorId = constructor != null ? constructor.Id : 1,
                StatusId = status != null ? status.Id : 1
            };

            return raceResult;
        }

        public static TimeSpan? GetTimeSpan(string time)
        {
            if (time == "\\N" || time == "")
                return null;
            time = time.Replace("\"", "");

            return new TimeSpan(Convert.ToInt32(time));
        }

        public static void LogUnmatchedProperties<T>(T entity, int Id) where T : class
        {
            if (entity == null)
                Console.WriteLine($"Could not find {typeof(T)} with Id: {Id}");
        }
    }
}
