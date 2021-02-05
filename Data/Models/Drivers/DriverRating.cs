using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Models.Drivers
{
    class DriverRating
    {
        public int Id { get; private set; }
        public int DriverId { get; set; }
        public int Round { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }

    }
}
