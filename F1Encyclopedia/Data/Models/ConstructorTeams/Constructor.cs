using Data.Models.Common;

namespace Data.Models.ConstructorTeams
{
    public class Constructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nationality Nationality { get; set; }

        public Colour[] TeamColours { get; set; }
    }
}
