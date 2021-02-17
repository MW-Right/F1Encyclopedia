using System;
using System.Collections.Generic;

namespace F1Encyclopedia.Data.Models.Common
{
    public class Country
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Nationality { get; set; }

        public Country() : base() { }

        public Country(string name, string continent, string nationality)
        {
            Name = name;
            Continent = continent;
            Nationality = nationality;
        }

        public static Country FromCsv(string line)
        {
            var values = line.Split(',');
            var country = new Country()
            {
                Name = values[0],
                Continent = values[1],
                Nationality = values[2]
            };

            return country;
        }
    }
}
