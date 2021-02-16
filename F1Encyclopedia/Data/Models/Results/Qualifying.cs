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
        public long? Q1 { get; set; }
        public long? Q2 { get; set;}
        public long? Q3 { get; set; }

        public static Qualifying FromCsv(string line)
        {
            var values = line.Split(',');

            using (var db = new F1EncyclopediaContext())
            {
                var raceWeekendId = Convert.ToInt32(values[1]);
                var driverId = Convert.ToInt32(values[2]);
                var constructorId = Convert.ToInt32(values[3]);

                var raceWeekend = db.RaceWeekends.FirstOrDefault(x =>
                    x.Id == Convert.ToInt32(values[1]));

                var driver = db.Persons.FirstOrDefault(x =>
                    x.Id == Convert.ToInt32(values[2]));

                var constructor = db.Constructors.FirstOrDefault(x =>
                    x.Id == Convert.ToInt32(values[3]));

                LogUnmatchedProperties(raceWeekend, raceWeekendId);
                LogUnmatchedProperties(driver, driverId);
                LogUnmatchedProperties(constructor, constructorId);

                var quali = new Qualifying()
                {
                    RaceWeekendId = raceWeekend != null ? raceWeekend.Id : 1,
                    DriverId = driver != null ? driver.Id : 1,
                    ConstructorId = constructor != null ? constructor.Id : 1,
                    Position = Convert.ToInt32(values[4]),
                    Q1 = GetMilllis(values[5]),
                    Q2 = GetMilllis(values[6]),
                    Q3 = GetMilllis(values[7])
                };

                return quali;
            }
        }

        public static long? GetMilllis(string time)
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

            return t.Milliseconds;
        }

        public static void LogUnmatchedProperties<T>(T entity, int Id) where T: class
        {
            if (entity == null)
                Console.WriteLine($"Could not find {typeof(T)} with Id: {Id}");
        }
    }
}
