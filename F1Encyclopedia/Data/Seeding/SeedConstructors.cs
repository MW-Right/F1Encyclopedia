using F1Encyclopedia.Data.Models.ConstructorTeams;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace F1Encyclopedia.Data.Seeding
{
    public class SeedConstructors
    {
        public static void ProcessErgastConstructors()
        {
            Debug.WriteLine("------+====== Constructors ======+------");
            string fileLocation = Seed.baseLocation + "constructors.csv";
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
                            Debug.WriteLine("Beginning processing.");
                            length = dataArr.Count();

                            foreach (var line in dataArr)
                            {
                                counter++;
                                if (counter % 10 == 0)
                                    Debug.Write($"\rProcessed: {counter} ({counter * 100 / length}%)");
                                data.Add(Constructor.FromCsv(line, db));
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
                    db.Constructors.AddIfNotExists(c, x => x.Name == c.Name);
                    if (counter % 10 == 0)
                        Debug.Write($"\rAdded: {counter} ({counter * 100 / length}%)");
                }
                Debug.WriteLine("\nEntities added and tracked, saving changes...");
                db.SaveChanges();
                Debug.WriteLine("Completed.\n\n\n\n");
            }
        }
    }
}
