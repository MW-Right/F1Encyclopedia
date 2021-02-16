using F1Encyclopedia.Data;
using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Models.Results;
using F1Encyclopedia.Data.Models.Tracks;
using F1Encyclopedia.Data.Seeding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcessErgastCountries();
            //ProcessErgastTracks();
            //ProcessErgastDrivers();
            //ProcessErgastRaceWeekends();
            ProcessErgastQualifying();
        }

        public static void ProcessErgastCountries()
        {
            string fileLocation = Seed.baseLocation + "countries.csv";
            var data = new List<Country>();
            var headers = new List<string>();

            using (var sr = new StreamReader(fileLocation))
            {
                headers = sr.ReadLine().Split(',').ToList();

                data = File.ReadAllLines(fileLocation)
                    .Skip(1)
                    .Select(x => Country.FromCsv(x))
                    .ToList();
            }

            using (var db = new F1EncyclopediaContext())
            {
                foreach (var c in data)
                {
                    db.Countries.AddIfNotExists(c, x => x.Name == c.Name);
                }
                db.SaveChanges();
            }
        }

        public static void ProcessErgastTracks()
        {
            string fileLocation = Seed.baseLocation + "circuits.csv";
            var data = new List<Track>();
            var headers = new List<string>();

            using (var sr = new StreamReader(fileLocation))
            {
                headers = sr.ReadLine().Split(',').ToList();

                data = File.ReadAllLines(fileLocation)
                    .Skip(1)
                    .Select(x => Track.FromCsv(x, headers))
                    .ToList();
            }

            using (var db = new F1EncyclopediaContext())
            {
                foreach (var t in data)
                {
                    db.Tracks.AddIfNotExists(t, x => x.Name == t.Name);
                }
                db.SaveChanges();
            }
        }

        public static void ProcessErgastDrivers()
        {
            string fileLocation = Seed.baseLocation + "drivers.csv";
            var data = new List<Person>();
            var headers = new List<string>();

            using (var sr = new StreamReader(fileLocation))
            {
                headers = sr.ReadLine().Split(',').ToList();

                data = File.ReadAllLines(fileLocation)
                    .Skip(1)
                    .Select(x => Person.FromCsv(x, headers))
                    .ToList();
            }

            using (var db = new F1EncyclopediaContext())
            {
                foreach (var d in data)
                {
                    db.Persons.AddIfNotExists(d, x => x.FirstName == d.FirstName && x.LastName == d.LastName);
                }
                db.SaveChanges();
            }
        }

        public static void ProcessErgastRaceWeekends()
        {
            string fileLocation = Seed.baseLocation + "races.csv";
            var data = new List<RaceWeekend>();

            using (var sr = new StreamReader(fileLocation))
            {
                data = File.ReadAllLines(fileLocation)
                    .Skip(1)
                    .Select(x => RaceWeekend.FromCsv(x))
                    .ToList();
            }

            using (var db = new F1EncyclopediaContext())
            {
                foreach (var rw in data)
                {
                    db.RaceWeekends.AddIfNotExists(rw, x => x.Name == rw.Name && x.Round == rw.Round && x.Year == rw.Year);
                }
                db.SaveChanges();
            }
        }

        public static void ProcessErgastQualifying()
        {
            string fileLocation = Seed.baseLocation + "qualifying.csv";
            var data = new List<Qualifying>();

            using (var sr = new StreamReader(fileLocation))
            {
                data = File.ReadAllLines(fileLocation)
                    .Skip(1)
                    .Select(x => Qualifying.FromCsv(x))
                    .ToList();
            }

            using (var db = new F1EncyclopediaContext())
            {
                foreach (var q in data)
                {
                    db.Qualifyings.AddIfNotExists(q, x => x.DriverId == q.DriverId && x.RaceWeekendId == q.RaceWeekendId);
                }
                db.SaveChanges();
            }
        }

        public static void PropertyException(string header)
        {
            throw new Exception($"Header: {header} was not found on object, please check the csv or add a new migration to add the new column to the db.");
        }
        
        // Redundant requests to Ergast API, requested the csv data.
        //public static async Task FetchDriverData(int season)
        //{
        //    var url = $"http://ergast.com/api/f1/{season}/drivers.json";

        //    using (var http = new HttpClient())
        //    {
        //        try
        //        {
        //            using (var response = await http.GetAsync(url))
        //            {
        //                response.EnsureSuccessStatusCode();
        //                var responseBody = await response.Content.ReadAsStringAsync();
                        
        //            }
        //        }
        //        catch(Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //    return new List<Person>();
        //}
    }
}
