using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Models.ConstructorTeams;
using F1Encyclopedia.Data.Models.Drivers;
using System;
using System.Linq;

namespace F1Encyclopedia.Data.Models.Results
{
    public class Qualifying
    {
        public int Id { get; set; }
        public int RaceWeekendId { get; set; }
        public RaceWeekend RaceWeekend { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public int ConstructorId { get; set; }
        public Constructor Constructor { get; set; }
        public int Position { get; set; }
        public TimeSpan? Q1 { get; set; }
        public TimeSpan? Q2 { get; set; }
        public TimeSpan? Q3 { get; set; }

        public static Qualifying FromCsv(string line, F1EncyclopediaContext db)
        {
            var values = line.Split(',');

            var correctedRaceWeekendId = RaceWeekend.RaceWeekendIdCorrection(values[1]);
            var correctedDriverId = Driver.DriverIdCorrection(values[2]);
            var correctedConstructorId = Constructor.ConstructorIdCorrection(values[3]);

            var raceWeekend = db.RaceWeekends.FirstOrDefault(x =>
                x.Id == Convert.ToInt32(values[1]));

            var driver = db.Drivers.FirstOrDefault(x =>
                x.Id == Convert.ToInt32(values[2]));

            var constructor = db.Constructors.FirstOrDefault(x =>
                x.Id == Convert.ToInt32(values[3]));

            LogUnmatchedProperties(raceWeekend, correctedRaceWeekendId);
            LogUnmatchedProperties(driver, correctedDriverId);
            LogUnmatchedProperties(constructor, correctedConstructorId);

            var quali = new Qualifying()
            {
                Id = Convert.ToInt16(values[0]),
                RaceWeekendId = raceWeekend != null ? raceWeekend.Id : 1,
                DriverId = driver != null ? driver.Id : 1,
                ConstructorId = constructor != null ? constructor.Id : 1,
                Position = Convert.ToInt32(values[4]),
                Q1 = GetTimeSpan(values[5]),
                Q2 = GetTimeSpan(values[6]),
                Q3 = GetTimeSpan(values[7])
            };

            return quali;
        }

        public static TimeSpan? GetTimeSpan(string time)
        {
            if (time == "\\N" || time == "")
                return null;
            time = time.Replace("\"", "");
            var minutes = Convert.ToInt32(time.Split(':')[0]);
            var secondsMillis = time.Split(':')[1].Split('.');

            var t = new TimeSpan(0, 0, minutes,
                Convert.ToInt32(secondsMillis[0]),
                Convert.ToInt32(secondsMillis[1])
            );

            return t;
        }

        public static void LogUnmatchedProperties<T>(T entity, int Id) where T : class
        {
            if (entity == null)
                Console.WriteLine($"Could not find {typeof(T)} with Id: {Id}");
        }
    }
}
