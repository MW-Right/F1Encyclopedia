using F1Encyclopedia.Data.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace F1Encyclopedia.Data.Models.Common
{
    public class RaceWeekend : F1Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Round { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }
        public string RaceWiki { get; set; }

        public static bool CheckHeadersCorrect(List<string> headers, out string badHeader)
            => CheckHeadersCorrect(headers, typeof(RaceWeekend), out badHeader);

        public static RaceWeekend FromCsv(string line, List<string> headers )
        {
            var values = line.Split(',');
            var dateParts = values[5].Replace("\"", "").Split('-');
            var timeParts = values[6].Replace("\"", "").Split(':');
            var raceWeekend = new RaceWeekend
            {
                Id = Convert.ToInt16(values[0]),
                Year = Convert.ToInt16(values[1]),
                Round = Convert.ToInt16(values[2]),
                TrackId = Convert.ToInt16(values[3]),
                Name = values[4].Replace("\"", ""),
                Date = timeParts.Length == 3 ?
                    new DateTime(
                        Convert.ToInt16(dateParts[0]),
                        Convert.ToInt16(dateParts[1]),
                        Convert.ToInt16(dateParts[2]),
                        Convert.ToInt16(timeParts[0]),
                        Convert.ToInt16(timeParts[1]),
                        Convert.ToInt16(timeParts[2])
                        ) :
                    new DateTime(
                        Convert.ToInt16(dateParts[0]),
                        Convert.ToInt16(dateParts[1]),
                        Convert.ToInt16(dateParts[2])
                        ),
                RaceWiki = values[7].Replace("\"", "")
            };

            return raceWeekend;
        }
    }
}
