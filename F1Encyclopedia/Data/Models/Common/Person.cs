using Data.Models.Common;
using Data.Models.ConstructorTeams;
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

        [UsedImplicitly]
        public Nationality Nationality { get; set; }
        
        public Role Role { get; set; }
        public EmployeeTeam[] Teams { get; set; }
    }
}
