using System;
using System.Collections.Generic;

namespace F1Encyclopedia.Data.Models.Common
{
    public class Country : F1Table
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

        public static bool CheckHeadersCorrect(List<string> headers, out string badHeader)
        {
            return F1Table.CheckHeadersCorrect(headers, typeof(Country), out badHeader);
        }

        public static Country FromCsv(string line, List<string> headers)
        {
            var values = line.Split(',');
            var country = new Country();

            return F1Table.FromCsv(values, headers, country);
        }
    }
}
