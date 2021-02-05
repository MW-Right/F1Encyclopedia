using Infrastructure.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Models.ConstructorTeams
{
    class EngineerTeam
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int ConstructorId { get; set; }
        public int RoleId{ get; set; }
        public RaceWeekend From { get; set; }
        public RaceWeekend To { get; set; }
    }
}
