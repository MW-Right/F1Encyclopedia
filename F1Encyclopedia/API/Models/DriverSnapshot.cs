using F1Encyclopedia.Data.Models.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.API.Models
{
    public class DriverSnapshot
    {
        public Driver Driver { get; set; }
        public float Points { get; set; }

        public DriverSnapshot() { }

        public DriverSnapshot(Driver driver, float points)
        {
            Driver = driver;
            Points = points;
        }
    }
}
