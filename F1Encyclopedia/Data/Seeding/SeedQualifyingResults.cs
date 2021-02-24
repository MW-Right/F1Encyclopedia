using F1Encyclopedia.Data.Models.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Seeding
{
    public class SeedQualifyingResults
    {
        public static void ProcessErgastQualifying()
        {
            Debug.WriteLine("------+====== Qualifying ======+------");
            string fileLocation = Seed.baseLocation + "qualifying.csv";
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

                            Debug.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                if (counter % 1000 == 0)
                                    Debug.Write($"\rProcessed: {counter} ({counter * 100 / length}%)");
                                data.Add(Qualifying.FromCsv(line, db));
                            }
                        }
                        docOpen = false;
                    }
                    catch (IOException e)
                    {
                        Debug.Write(e.Message);
                        Debug.WriteLine("\rLap_times.csv file is open in another location. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Debug.WriteLine("\nCompleted processing data. Starting add.");

                using (var transaction = db.Database.BeginTransaction())
                {
                    foreach (var q in data)
                    {
                        counter++;
                        db.Qualifyings.AddIfNotExists(q, x => x.DriverId == q.DriverId && x.RaceWeekendId == q.RaceWeekendId);
                        if (counter % 1000 == 0)
                            Debug.Write($"\rAdded: {counter} ({counter * 100 / length}%)");
                    }
                    Seed.AddWithIdentityInsert("Qualifyings", transaction, db);
                }
            }
        }
    }
}
