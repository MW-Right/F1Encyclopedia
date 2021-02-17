using F1Encyclopedia.Data;
using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Models.ConstructorTeams;
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
            using (var context = new F1EncyclopediaContext())
            {
                context.CleanTable("RaceResults");
                context.CleanTable("LapTimes");
                context.CleanTable("RaceStatuses");
                context.CleanTable("Qualifyings");
                context.CleanTable("Constructors");
                context.CleanTable("RaceWeekends");
                context.CleanTable("Persons");
                context.CleanTable("Tracks");
                context.CleanTable("Countries");
            }

            /* Order of seeding:
             * Countries
             * Tracks
             * Drivers
             * RaceWeekends
             * Constructors
             * Qualifying
             * RaceStatuses
             * LapTime
             * RaceResults
             */
            ProcessErgastCountries();
            ProcessErgastTracks();
            ProcessErgastDrivers();
            ProcessErgastRaceWeekends();
            ProcessErgastConstructors();
            ProcessErgastQualifying();
            ProcessErgastRaceStatus();
            ProcessErgastLapTimes();
            ProcessErgastRaceResults();
        }

        public static void ProcessErgastCountries()
        {
            var fileLocation = Seed.baseLocation + "countries.csv";
            var counter = 0;
            var length = 0;
            var docOpen = true;

            var data = new List<Country>();

            using (var db = new F1EncyclopediaContext())
            {
                while (docOpen)
                {
                    try
                    {
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var dataArr = File.ReadAllLines(fileLocation);
                            
                            Console.WriteLine("Beginning processing.\n");
                            length = dataArr.Length;

                            data = File.ReadAllLines(fileLocation)
                                .Skip(1)
                                .Select(x =>
                                {
                                    counter++;
                                    Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100/ length);
                                    return Country.FromCsv(x);
                                })
                                .ToList();
                            docOpen = false;
                        }
                    }
                    catch (IOException e)
                    {
                        Console.Write(e.Message);
                        Console.WriteLine("\rCSV file is open in another application. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Console.WriteLine("Completed processing. Starting add.");

                foreach (var c in data)
                {
                    counter++;
                    db.Countries.AddIfNotExists(c, x => x.Name == c.Name);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("Entities added and tracked, saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.");
            }
        }

        public static void ProcessErgastTracks()
        {
            var fileLocation = Seed.baseLocation + "circuits.csv";
            var counter = 0;
            var length = 0;
            var docOpen = true;

            var data = new List<Track>();

            using (var db = new F1EncyclopediaContext()) 
            {
                while (docOpen)
                {
                    try
                    {
                        // Checks file is currently open.
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var dataArr = File.ReadAllLines(fileLocation);

                            Console.WriteLine("Beginning processing.\n");
                            length = dataArr.Length;

                            data = File.ReadAllLines(fileLocation)
                                .Skip(1)
                                .Select(x =>
                                {
                                    counter++;
                                    Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                    return Track.FromCsv(x);
                                })
                                .ToList();

                            docOpen = false;
                        }
                    }
                    catch (IOException e)
                    {
                        Console.Write(e.Message);
                        Console.WriteLine("\rCSV file is open in another application. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Console.WriteLine("Completed processing. Starting add.");

                foreach (var t in data)
                {
                    counter++;
                    db.Tracks.AddIfNotExists(t, x => x.Name == t.Name);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("Entities added and tracked. Saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed");
            }
        }

        public static void ProcessErgastDrivers()
        {
            var fileLocation = Seed.baseLocation + "drivers.csv";
            var counter = 0;
            var length = 0;
            var docOpen = true;

            var data = new List<Person>();

            using (var db = new F1EncyclopediaContext())
            {
                while(docOpen)
                {
                    try
                    {
                        // Checks file is currently open.
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var dataArr = File.ReadAllLines(fileLocation);

                            Console.WriteLine("Beginning processing.\n");
                            length = dataArr.Length;

                            data = File.ReadAllLines(fileLocation)
                                .Skip(1)
                                .Select(x => 
                                {
                                    counter++;
                                    Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                    return Person.FromCsv(x); 
                                })
                                .ToList();

                            docOpen = false;
                        }
                    }
                    catch (IOException e)
                    {
                        Console.Write(e.Message);
                        Console.WriteLine("\rCSV file is open in another application. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Console.WriteLine("Completed processing. Starting add.");

                foreach (var d in data)
                {
                    counter++;
                    db.Persons.AddIfNotExists(d, x => x.FirstName == d.FirstName && x.LastName == d.LastName);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("Entities added and tracked. Saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.");
            }
        }

        public static void ProcessErgastRaceWeekends()
        {
            string fileLocation = Seed.baseLocation + "races.csv";
            var data = new List<RaceWeekend>();

            // Checks file is currently open.
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

            // Checks file is currently open.
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

        public static void ProcessErgastConstructors()
        {
            string fileLocation = Seed.baseLocation + "constructors.csv";
            var data = new List<Constructor>();

            // Checks file is currently open.
            using (var sr = new StreamReader(fileLocation))
            {
                data = File.ReadAllLines(fileLocation)
                    .Skip(1)
                    .Select(x => Constructor.FromCsv(x))
                    .ToList();
            }

            using (var db = new F1EncyclopediaContext())
            {
                foreach (var c in data)
                {
                    db.Constructors.AddIfNotExists(c, x => x.Name == c.Name);
                }
                db.SaveChanges();
            }
        }

        public static void ProcessErgastRaceStatus()
        {
            string fileLocation = Seed.baseLocation + "status.csv";
            var data = new List<RaceStatus>();

            // Checks file is currently open.
            using (var sr = new StreamReader(fileLocation))
            {
                data = File.ReadAllLines(fileLocation)
                    .Skip(1)
                    .Select(x => RaceStatus.FromCsv(x))
                    .ToList();
            }

            using (var db = new F1EncyclopediaContext())
            {
                foreach (var rs in data)
                {
                    db.RaceStatuses.AddIfNotExists(rs, x => x.Status == rs.Status);
                }
                db.SaveChanges();
            }
        }

        public static void ProcessErgastRaceResults()
        {
            string fileLocation = Seed.baseLocation + "results.csv";
            var data = new List<RaceResult>();

            using (var db = new F1EncyclopediaContext())
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    data = File.ReadAllLines(fileLocation)
                        .Skip(1)
                        .Select(x => RaceResult.FromCsv(x, db))
                        .ToList();
                }

                foreach (var rr in data)
                {
                    db.RaceResults.AddIfNotExists(rr,
                        x => x.RaceWeekendId == rr.RaceWeekendId && x.DriverId == rr.DriverId);
                }
                db.SaveChanges();
            }
        }

        public static void ProcessErgastLapTimes()
        {
            string fileLocation = Seed.baseLocation + "lap_times.csv";
            var data = new List<LapTime>();
            var docOpen = true;
            var counter = 0;
            var length = 0;

            using (var db = new F1EncyclopediaContext())
            {
                while (docOpen)
                {
                    try
                    {
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var fileArr = File.ReadAllLines(fileLocation);
                            length = fileArr.Length;
                            data = fileArr.Skip(1)
                                .Select(x =>
                                {
                                    Console.Write("\rProcessed: {0}", counter, counter * 100 / length);
                                    return LapTime.FromCsv(x, db);
                                })
                                .ToList();
                        }
                        docOpen = false;
                    }
                    catch (IOException e)
                    {
                        docOpen = true;
                        Console.WriteLine("CSV file is open in another application. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Console.WriteLine("Completed processing data. Starting add.\n");

                foreach (var lt in data)
                {
                    db.LapTimes.AddIfNotExists(lt, x =>
                        x.RaceWeekendId == lt.RaceWeekendId &&
                        x.DriverId == lt.DriverId &&
                        x.Lap == lt.Lap);
                    Console.Write("\rAdded: {0}", counter += 1);
                }
                Console.WriteLine("Entities added and tracked, saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.");
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
