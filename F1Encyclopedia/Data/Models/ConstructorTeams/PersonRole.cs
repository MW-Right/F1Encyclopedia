using F1Encyclopedia.Data.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Encyclopedia.Data.Models.ConstructorTeams
{
    public class PersonRole
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Person Employee { get; set; }

        public int ConstructorId { get; set; }
        public Constructor Constructor{ get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int FromId { get; set; }

        [ForeignKey("FromId")]
        public RaceWeekend From { get; set; }

        public int ToId { get; set; }

        [ForeignKey("ToId")]
        public RaceWeekend To { get; set; }
    }
}
