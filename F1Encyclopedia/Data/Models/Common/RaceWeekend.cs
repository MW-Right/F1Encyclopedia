using F1Encyclopedia.Data.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace F1Encyclopedia.Data.Models.Common
{
    public class RaceWeekend
    {
        public int Id { get; set; }
        public int Round { get; set; }
        public int Year { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }
    }
}
