using F1Encyclopedia.Data.Models.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Seeding
{
    public class SeedLapTimes
    {
        public static void ProcessErgastLapTimes()
        {
            Debug.WriteLine("------+====== Lap Times ======+------");
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
                        // Checks file is currently open.
                        using (var sr = new StreamReader(fileLocation))
                        {
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);
                            Debug.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                if (counter % 10000 == 0)
                                    Debug.Write($"\rProcessed: {counter} ({counter * 100 / length}%)");
                                data.Add(LapTime.FromCsv(line, db));
                            }
                        }
                        docOpen = false;
                    }
                    catch (IOException e)
                    {
                        Debug.Write(e.Message);
                        Debug.WriteLine("\rCSV file is open in another application. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Debug.WriteLine("\nCompleted processing data. Starting add.");

                using (var transaction = db.Database.BeginTransaction())
                {
                    foreach (var lt in data)
                    {
                        counter++;
                        db.LapTimes.AddIfNotExists(lt, x =>
                            x.RaceWeekendId == lt.RaceWeekendId &&
                            x.DriverId == lt.DriverId &&
                            x.Lap == lt.Lap);
                        if (counter % 10000 == 0)
                            Debug.Write($"\rAdded: {counter} ({counter * 100 / length}%)");
                    }
                    Seed.AddWithoutIdentityInsert(transaction, db);
                }
            }
        }

    }
}
