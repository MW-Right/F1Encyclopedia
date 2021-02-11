using F1Encyclopedia.Data.Models.ConstructorTeams;
using F1Encyclopedia.Data.Models.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace F1Encyclopedia.Data.Models.Common
{
    public class Person : F1Table
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

        public static bool CheckHeadersCorrect(List<string> headers, out string badHeader)
        {
            return CheckHeadersCorrect(headers, typeof(Person), out badHeader);
        }

        public static Person FromCsv(string line, List<string> headers)
        {
            var values = line.Split(',');
            var person = new Person();
            var customTypeData = "";

            var incompleteData = F1Table.FromCsv(values, headers, person, ref customTypeData);

            if (customTypeData == "")
            {
                return incompleteData;
            }
            else
            {
                using (var db = new F1EncyclopediaContext())
                {
                    var country = db.Countries
                        .Where(p => p.Nationality == customTypeData)
                        .FirstOrDefault();

                    if (country != null)
                    {
                        person.CountryId = country.Id;
                    }
                }
            }

            return person;
        }
    }
}
