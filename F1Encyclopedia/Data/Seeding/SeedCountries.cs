using F1Encyclopedia.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Seeding
{
    public static class SeedCountries
    {
        public static void ProcessErgastCountries()
        {
            Debug.WriteLine("------+====== Countries ======+------");
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
                            var dataArr = File.ReadAllLines(fileLocation).Skip(1);

                            Debug.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                if (counter % 10 == 0)
                                    Debug.Write($"\rProcessed: {counter} ({counter * 100 / length}%)");

                                data.Add(Country.FromCsv(line));
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
                    foreach (var c in data)
                    {
                        counter++;
                        db.Countries.AddIfNotExists(c, x => x.Name == c.Name);
                        if (counter % 10 == 0)
                            Debug.Write($"\rAdded: {counter} ({counter * 100 / length}%)");
                    }
                    Seed.AddWithoutIdentityInsert(transaction, db);
                }
            }
        }
    }
}
