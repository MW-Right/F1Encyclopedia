using F1Encyclopedia.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Seeding
{
    public static class SeedCountries
    {
        public static string resetIdentity = "DBCC CHECKIDENT('Countries', RESEED, 0); GO";
        public static void ProcessErgastCountries()
        {
            string fileLocation = Seed.baseLocation + "countries.csv";
            var data = new List<Country>();
            var headers = new List<string>();

            using (var sr = new StreamReader(fileLocation))
            {
                headers = sr.ReadLine().Split(',').ToList();

                data = File.ReadAllLines(fileLocation)
                    .Skip(1)
                    .Select(x => Country.FromCsv(x))
                    .ToList();
            }

            using (var db = new F1EncyclopediaContext())
            {
                foreach (var c in data)
                {
                    db.Countries.AddIfNotExists(c, x => x.Name == c.Name);
                }
                db.SaveChanges();
            }
        }
    }
}
