﻿using Data.Models.Common;
using Data.Models.ConstructorTeams;
using F1Encyclopedia.Data.Models.Common;

namespace Data.Models.Drivers
{
    public class DriverInformation : Person
    {
        public int DriverInformationId { get; private set; }
        public Person Driver { get; set; }
        public int Number { get; set; }
        public bool DaddysCash { get; set; }
        public int Pace { get; set; }
        public int Experience { get; set; }
        public int Racecraft { get; set; }
        public int Awareness { get; set; }
        public DriverRating[] DriverRatings { get; set; }
    }
}