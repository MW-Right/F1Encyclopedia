using F1Encyclopedia.Data.Models.ConstructorTeams;
using F1Encyclopedia.Data.Models.Drivers;
using F1Encyclopedia.Data.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace F1Encyclopedia.Data.Models.Common
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }

        public string WikiUrl { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        private string Nationality => Country.Nationality;

        public int? DriverInformationId { get; set; }
        public DriverInformation DriverInformation { get; set; }
        
        public List<PersonRole> Teams { get; set; }
        public List<DriverRating> DriverRatings { get; set; }


        public static Person FromCsv(string line)
        {
            var values = line.Split(',');
            
            using (var db = new F1EncyclopediaContext())
            {
                values[4] = Seed.UpdateNationalities(values[4]);

                var country = db.Countries
                    .Where(p => p.Nationality == values[4])
                    .FirstOrDefault();

                if (country == null)
                {
                    Console.WriteLine($"Country not found from nationality: {values[4]}");
                }

                var person = new Person()
                {
                    FirstName = values[1],
                    LastName = values[2],
                    DoB = DateTime.Parse(values[3]),
                    CountryId = country != null ? country.Id : 1,
                    WikiUrl = values[5]
                };

                return person;
            }
        }

        /// <summary>
        ///     When seeding the db using the ergast db csvs, the driver ids are not sequential. Correction applied to keep referential accuracy.
        /// </summary>
        /// <param name="id">
        ///     The Driver identifier to check.
        /// </param>
        /// <returns>
        ///     Corrected driver identifier.
        /// </returns>
        public static int DriverIdCorrection(string stringId)
        {
            var id = Convert.ToInt32(stringId);
            switch (id)
            {
                case > 809:
                    return id -= 1;
            }
            return id;
        }
    }
}
