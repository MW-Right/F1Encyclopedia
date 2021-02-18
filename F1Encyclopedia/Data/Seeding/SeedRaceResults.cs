using F1Encyclopedia.Data.Models.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Seeding
{
    public class SeedRaceResults
    {
        public static void ProcessErgastRaceResults()
        {
            Debug.WriteLine("------+====== Race Results ======+------");
            string fileLocation = Seed.baseLocation + "results.csv";
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
                            Debug.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                if (counter % 10000 == 0)
                                    Debug.Write($"\rProcessed: {counter} ({counter * 100 / length}%)");
                                data.Add(RaceResult.FromCsv(line, db));
                            }
                        }
                        docOpen = false;
                    }
                    catch (IOException e)
                    {
                        Debug.Write(e.Message);
                        Debug.WriteLine("\rConstructors.csv is open in another location. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Debug.WriteLine("\nCompleted processing data. Starting add.");

                foreach (var c in data)
                {
                    counter++;
                    db.RaceResults.AddIfNotExists(c, x =>
                        x.RaceWeekendId == c.RaceWeekendId &&
                        x.DriverId == c.DriverId);
                    if (counter % 10000 == 0)
                        Debug.Write($"\rAdded: {counter} ({counter * 100 / length}%)");
                }
                Debug.WriteLine("\nEntities added and tracked, saving changes...");
                db.SaveChanges();
                Debug.WriteLine("Completed.\n\n\n\n");
            }
        }

    }
}
