using F1Encyclopedia.Data.Models.Drivers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace F1Encyclopedia.Data.Seeding
{
    public class SeedDrivers
    {
        public static void ProcessErgastDrivers()
        {
            Debug.WriteLine("------+====== Drivers  ======+------");
            var fileLocation = Seed.baseLocation + "drivers.csv";
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

                            Debug.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                if (counter % 10 == 0)
                                    Debug.Write($"\rProcessed: {counter} ({counter * 100 / length}%)");
                                data.Add(Driver.FromCsv(line, db));
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

                using (var transaction = db.Database.BeginTransaction())
                {
                    foreach (var d in data)
                    {
                        counter++;
                        db.Drivers.AddIfNotExists(d, x => x.FirstName == d.FirstName && x.LastName == d.LastName);
                        if (counter % 10 == 0)
                            Debug.Write($"\rAdded: {counter} ({counter * 100 / length}%)");
                    }
                    Seed.AddWithIdentityInsert("Drivers", transaction, db);
                }
            }
        }
    }
}
