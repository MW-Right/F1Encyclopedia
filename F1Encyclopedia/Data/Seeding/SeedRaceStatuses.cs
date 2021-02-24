using F1Encyclopedia.Data.Models.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Seeding
{
    public class SeedRaceStatuses
    {
        public static void ProcessErgastRaceStatus()
        {
            Debug.WriteLine("------+====== Race statuses ======+------");
            string fileLocation = Seed.baseLocation + "status.csv";
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
                            Debug.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                if (counter % 10 == 0)
                                    Debug.Write($"\rProcessed: {counter} ({counter * 100 / length}%)");
                                data.Add(RaceStatus.FromCsv(line));
                            }
                        }
                        docOpen = false;
                    }
                    catch (IOException e)
                    {
                        Debug.Write(e.Message);
                        Debug.WriteLine("\rstatus.csv is open in another location. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Debug.WriteLine("\nCompleted processing data. Starting add.");

                using (var transaction = db.Database.BeginTransaction())
                {
                    foreach (var c in data)
                    {
                        counter++;
                        db.RaceStatuses.AddIfNotExists(c, x => x.Status == c.Status);
                        if (counter % 10 == 0)
                            Debug.Write($"\rAdded: {counter} ({counter * 100 / length}%)");
                    }
                    Seed.AddWithIdentityInsert("RaceStatuses", transaction, db);
                }
            }
        }

    }
}
