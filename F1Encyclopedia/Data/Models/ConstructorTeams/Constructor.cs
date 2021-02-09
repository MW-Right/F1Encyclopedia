using Data.Models.Common;
using Data.Models.Drivers;
using System.Collections.Generic;

namespace Data.Models.ConstructorTeams
{
    public class Constructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TitleSponsor { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<Colour> TeamColours { get; set; }
        public List<PersonRole> Staff { get; set; }
    }
}
