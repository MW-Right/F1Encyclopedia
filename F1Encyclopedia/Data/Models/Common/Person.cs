using F1Encyclopedia.Data.Models.ConstructorTeams;
using F1Encyclopedia.Data.Models.Drivers;
using System;
using System.Collections.Generic;

namespace F1Encyclopedia.Data.Models.Common
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }

        public int NationalityId { get; set; }
        public Country Country { get; set; }

        private string Nationality => Country.Nationality;

        public int? DriverInformationId { get; set; }
        public DriverInformation DriverInformation { get; set; }
        
        public List<PersonRole> Teams { get; set; }
        public List<DriverRating> DriverRatings { get; set; }
    }
}
