using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.ConstructorTeams
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Role(string role)
        {
            Name = role;
        }
    }
}
