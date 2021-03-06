﻿using F1Encyclopedia.Data.Models.Common;
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
        public int Lap { get; set; }
        public int Position { get; set; }
        public TimeSpan Time { get; set; }
        public long TimeMillis => Time.Milliseconds;

        public static LapTime FromCsv(string line, F1EncyclopediaContext context)
        {
            var values = line.Split(',');
            var raceWeekendId = RaceWeekend.RaceWeekendIdCorrection(values[0]);
            var driverId = Person.DriverIdCorrection(values[1]);

            var raceWeekend = context.RaceWeekends.FirstOrDefault(x => x.Id == raceWeekendId);
            var driver = context.Persons.FirstOrDefault(x => x.Id == driverId);

            LogUnmatchedProperties(driver, driverId);
            LogUnmatchedProperties(raceWeekend, raceWeekendId);

            return new LapTime()
            {
                RaceWeekendId = raceWeekend != null ? raceWeekend.Id : 1,
                DriverId = driver != null ? driver.Id : 1,
                Lap = Convert.ToInt32(values[2]),
                Position = Convert.ToInt32(values[3]),
                Time = GetTimeSpan(values[5])
            };
        }

        public static TimeSpan GetTimeSpan(string time)
        {
            time = time.Replace("\"", "");

            // 10,000 ticks in a millisecond.
            return new TimeSpan(Convert.ToInt32(time) * 10000);
        }

        public static void LogUnmatchedProperties<T>(T entity, int Id) where T : class
        {
            if (entity == null)
                Console.WriteLine($"Could not find {typeof(T)} with Id: {Id}");
        }
    }
}
