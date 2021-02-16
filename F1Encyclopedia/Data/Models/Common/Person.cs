using F1Encyclopedia.Data.Models.ConstructorTeams;
using F1Encyclopedia.Data.Models.Drivers;
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


        public static Person FromCsv(string line, List<string> headers)
        {
            var values = line.Split(',');
            
            using (var db = new F1EncyclopediaContext())
            {
                switch (values[4])
                {
                    case "Rhodesian":
                        {
                            values[4] = "Zimbabwean";
                            break;
                        }
                    case "East German":
                        {
                            values[4] = "German";
                            break;
                        }
                    case "Argentine-Italian":
                        {
                            values[4] = "Argentine";
                            break;
                        }
                    case "American-Italian":
                        {
                            values[4] = "American";
                            break;
                        }
                    default: break;
                }

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
    }
}
