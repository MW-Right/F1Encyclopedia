using F1Encyclopedia.Data;
using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Models.ConstructorTeams;
using F1Encyclopedia.Data.Models.Drivers;
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
        public static string baseLocation = "..\\..\\..\\..\\DataTrawl\\";
        static void Main(string[] args)
        {
            using (var context = new F1EncyclopediaContext())
            {
                context.CleanTable("RaceResults");
                context.CleanTable("LapTimes");
                context.CleanTable("RaceStatuses");
                context.CleanTable("Qualifyings");
                //context.CleanTable("Constructors");
                //context.CleanTable("RaceWeekends");
                context.CleanTable("Drivers");
                //context.CleanTable("Tracks");
                //context.CleanTable("Countries");
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
            //ProcessErgastCountries();
            //ProcessErgastTracks();
            ProcessErgastDrivers();
            //ProcessErgastRaceWeekends();
            //ProcessErgastConstructors();
            ProcessErgastQualifying();
            ProcessErgastRaceStatus();
            ProcessErgastLapTimes();
            ProcessErgastRaceResults();
        }

        public static void ProcessErgastCountries()
        {
            Console.WriteLine("------+====== Countries ======+------");
            var fileLocation = baseLocation + "countries.csv";
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
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);

                            Console.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                data.Add(Country.FromCsv(line));
                            }

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
                Console.WriteLine("\nCompleted processing. Starting add.");

                foreach (var c in data)
                {
                    counter++;
                    db.Countries.AddIfNotExists(c, x => x.Name == c.Name);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("\nEntities added and tracked, saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed. \n\n\n\n");
            }
        }

        public static void ProcessErgastTracks()
        {
            Console.WriteLine("------+====== Tracks ======+------");
            var fileLocation = baseLocation + "circuits.csv";
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
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);

                            Console.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                data.Add(Track.FromCsv(line));
                            }

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
                Console.WriteLine("\nCompleted processing. Starting add.");

                foreach (var t in data)
                {
                    counter++;
                    db.Tracks.AddIfNotExists(t, x => x.Name == t.Name);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("\nEntities added and tracked. Saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.\n\n\n\n");
            }
        }

        public static void ProcessErgastDrivers()
        {
            Console.WriteLine("------+====== Drivers  ======+------");
            var fileLocation = baseLocation + "drivers.csv";
            var counter = 0;
            var length = 0;
            var docOpen = true;

            var data = new List<Driver>();

            using (var db = new F1EncyclopediaContext())
            {
                while (docOpen)
                {
                    try
                    {
                        // Checks file is currently open.
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);

                            Console.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                data.Add(Driver.FromCsv(line, db));
                            }

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
                Console.WriteLine("\nCompleted processing. Starting add.");

                foreach (var d in data)
                {
                    counter++;
                    db.Drivers.AddIfNotExists(d, x => x.FirstName == d.FirstName && x.LastName == d.LastName);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("\nEntities added and tracked. Saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.\n\n\n\n");
            }
        }

        public static void ProcessErgastRaceWeekends()
        {
            Console.WriteLine("------+====== Race weekends  ======+------");
            string fileLocation = baseLocation + "races.csv";
            var counter = 0;
            var length = 0;
            var docOpen = true;

            var data = new List<RaceWeekend>();


            using (var db = new F1EncyclopediaContext())
            {
                while (docOpen)
                {
                    try
                    {
                        // Checks file is currently open.
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);
                            Console.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                data.Add(RaceWeekend.FromCsv(line));
                            }
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
                Console.WriteLine("\nCompleted processing. Starting add.");

                foreach (var rw in data)
                {
                    counter++;
                    db.RaceWeekends.AddIfNotExists(rw, x => x.Name == rw.Name && x.Round == rw.Round && x.Year == rw.Year);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("\nEntities added and tracked, saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.\n\n\n\n");
            }
        }

        public static void ProcessErgastQualifying()
        {
            Console.WriteLine("------+====== Qualifying ======+------");
            string fileLocation = baseLocation + "qualifying.csv";
            var data = new List<Qualifying>();
            var docOpen = true;
            var counter = 0;
            var length = 0;

            using (var db = new F1EncyclopediaContext())
            {
                while (docOpen)
                {
                    try
                    {
                        // Checks file is currently open.
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);

                            Console.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                data.Add(Qualifying.FromCsv(line, db));
                            }
                        }
                        docOpen = false;
                    }
                    catch (IOException e)
                    {
                        Console.Write(e.Message);
                        Console.WriteLine("\rLap_times.csv file is open in another location. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Console.WriteLine("\nCompleted processing data. Starting add.");

                foreach (var q in data)
                {
                    counter++;
                    db.Qualifyings.AddIfNotExists(q, x => x.DriverId == q.DriverId && x.RaceWeekendId == q.RaceWeekendId);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("\nEntities added and tracked, saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.\n\n\n\n");
            }
        }

        public static void ProcessErgastConstructors()
        {
            Console.WriteLine("------+====== Constructors ======+------");
            string fileLocation = baseLocation + "constructors.csv";
            var data = new List<Constructor>();
            var docOpen = true;
            var counter = 0;
            var length = 0;

            using (var db = new F1EncyclopediaContext())
            {
                while (docOpen)
                {
                    try
                    {
                        // Checks file is currently open.
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);
                            Console.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                data.Add(Constructor.FromCsv(line, db));
                            }
                        }
                        docOpen = false;
                    }
                    catch (IOException e)
                    {
                        Console.Write(e.Message);
                        Console.WriteLine("\rConstructors.csv is open in another location. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Console.WriteLine("\nCompleted processing data. Starting add.");

                foreach (var c in data)
                {
                    counter++;
                    db.Constructors.AddIfNotExists(c, x => x.Name == c.Name);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("\nEntities added and tracked, saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.\n\n\n\n");
            }
        }

        public static void ProcessErgastRaceStatus()
        {
            Console.WriteLine("------+====== Race statuses ======+------");
            string fileLocation = baseLocation + "status.csv";
            var data = new List<RaceStatus>();
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
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);
                            Console.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                data.Add(RaceStatus.FromCsv(line));
                            }
                        }
                        docOpen = false;
                    }
                    catch (IOException e)
                    {
                        Console.Write(e.Message);
                        Console.WriteLine("\rstatus.csv is open in another location. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Console.WriteLine("\nCompleted processing data. Starting add.");

                foreach (var c in data)
                {
                    counter++;
                    db.RaceStatuses.AddIfNotExists(c, x => x.Status == c.Status);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("\nEntities added and tracked, saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.\n\n\n\n");
            }
        }

        public static void ProcessErgastRaceResults()
        {
            Console.WriteLine("------+====== Race Results ======+------");
            string fileLocation = baseLocation + "results.csv";
            var data = new List<RaceResult>();
            var docOpen = true;
            var length = 0;
            var counter = 0;

            using (var db = new F1EncyclopediaContext())
            {
                while (docOpen)
                {
                    try
                    {
                        // Checks file is currently open.
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);
                            Console.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                data.Add(RaceResult.FromCsv(line, db));
                            }
                        }
                        docOpen = false;
                    }
                    catch (IOException e)
                    {
                        Console.Write(e.Message);
                        Console.WriteLine("\rConstructors.csv is open in another location. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Console.WriteLine("\nCompleted processing data. Starting add.");

                foreach (var c in data)
                {
                    counter++;
                    db.RaceResults.AddIfNotExists(c, x =>
                        x.RaceWeekendId == c.RaceWeekendId &&
                        x.DriverId == c.DriverId);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("\nEntities added and tracked, saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.\n\n\n\n");
            }
        }

        public static void ProcessErgastLapTimes()
        {
            Console.WriteLine("------+====== Lap Times ======+------");
            string fileLocation = baseLocation + "lap_times.csv";
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
                        // Checks file is currently open.
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);
                            Console.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                Console.Write("\rProcessed: {0} ({1}%)", counter, counter * 100 / length);
                                data.Add(LapTime.FromCsv(line, db));
                            }
                        }
                        docOpen = false;
                    }
                    catch (IOException e)
                    {
                        Console.Write(e.Message);
                        Console.WriteLine("\rCSV file is open in another application. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Console.WriteLine("\nCompleted processing data. Starting add.");

                foreach (var lt in data)
                {
                    counter++;
                    db.LapTimes.AddIfNotExists(lt, x =>
                        x.RaceWeekendId == lt.RaceWeekendId &&
                        x.DriverId == lt.DriverId &&
                        x.Lap == lt.Lap);
                    Console.Write("\rAdded: {0} ({1}%)", counter, counter * 100 / length);
                }
                Console.WriteLine("\nEntities added and tracked, saving changes...");
                db.SaveChanges();
                Console.WriteLine("Completed.\n\n\n\n");
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
