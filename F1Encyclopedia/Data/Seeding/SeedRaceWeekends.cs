using F1Encyclopedia.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Seeding
{
    public class SeedRaceWeekends
    {
        public static void ProcessErgastRaceWeekends()
        {
            Debug.WriteLine("------+====== Race weekends  ======+------");
            string fileLocation = Seed.baseLocation + "races.csv";
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
                            Debug.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                if (counter % 100 == 0)
                                    Debug.Write($"\rProcessed: {counter} ({counter * 100 / length}%)");
                                data.Add(RaceWeekend.FromCsv(line));
                            }
                            docOpen = false;
                        }
                    }
                    catch (IOException e)
                    {
                        Debug.Write(e.Message);
                        Debug.WriteLine("\rCSV file is open in another application. Please close to continue.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                counter = 0;
                Debug.WriteLine("\nCompleted processing. Starting add.");

                foreach (var rw in data)
                {
                    counter++;
                    db.RaceWeekends.AddIfNotExists(rw, x => x.Name == rw.Name && x.Round == rw.Round && x.Year == rw.Year);
                    if (counter % 100 == 0)
                        Debug.Write($"\rAdded: {counter} ({counter * 100 / length}%)");
                }
                Debug.WriteLine("\nEntities added and tracked, saving changes...");
                db.SaveChanges();
                Debug.WriteLine("Completed.\n\n\n\n");
            }
        }
    }
}
