using Data.Models.Common;
using Data.Models.ConstructorTeams;
using Data.Models.Drivers;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Models.Common
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }

        public int NationalityId { get; set; }
        public Country Nationality { get; set; }

        public int DriverInformationId { get; set; }
        public DriverInformation DriverInformation { get; set; }
        
        public List<PersonRole> Teams { get; set; }
        public List<DriverRating> DriverRatings { get; set; }
    }
}
