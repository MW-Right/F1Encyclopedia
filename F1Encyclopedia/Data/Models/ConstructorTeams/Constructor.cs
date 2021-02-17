using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Seeding;
using System.Collections.Generic;
using System.Linq;
using System;

namespace F1Encyclopedia.Data.Models.ConstructorTeams
{
    public class Constructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string WikiUrl { get; set; }

        public List<Colour> TeamColours { get; set; }
        public List<PersonRole> Staff { get; set; }

        public static Constructor FromCsv(string line)
        {
            var values = line.Split(',');

            using (var db = new F1EncyclopediaContext())
            {
                values[2] = Seed.UpdateNationalities(values[2]);

                var country = db.Countries.FirstOrDefault(x => x.Nationality == values[2]);

                if (country == null)
                {
                    Console.WriteLine($"Country not found with nationality: {values[2]}");   
                }

                var constructor = new Constructor()
                {
                    Name = values[1],
                    CountryId = country != null ? country.Id : 1,
                    WikiUrl = values[3]
                };

                return constructor;
            }
        }


        /// <summary>
        ///     When seeding the db using the ergast db CSVs, the constructor ids are not sequential. Correction applied to keep referential accuracy.
        /// </summary>
        /// <param name="id">
        ///     The Constructor identifier to check.
        /// </param>
        /// <returns>
        ///     Corrected constructor identifier.
        /// </returns>
        public static int ConstructorIdCorrection(string stringId)
        {
            var id = Convert.ToInt32(stringId);
            switch (id)
            {
                case > 211:
                    return id -= 3;
                case > 164:
                    return id -= 2;
                case > 42:
                    return id -= 1;
            }
            return id;
        }
    }
}
