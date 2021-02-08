using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Drivers
{
    public class DriverRating
    {
        public int Id { get; private set; }
        public DriverInformation Driver { get; set; }
        public int Round { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }

    }
}
