using Data.Models.Common;
using Data.Models.Drivers;
using F1Encyclopedia.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.ConstructorTeams
{
    public class EngineerTeam
    {
        public int Id { get; set; }
        public Person Employee { get; set; }
        public Constructor Constructor{ get; set; }
        public Role Role { get; set; }
        public RaceWeekend From { get; set; }
        public RaceWeekend To { get; set; }
    }
}
