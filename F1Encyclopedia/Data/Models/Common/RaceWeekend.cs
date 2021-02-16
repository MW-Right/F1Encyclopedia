using F1Encyclopedia.Data.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F1Encyclopedia.Data.Models.Common
{
    public class RaceWeekend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Round { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }
        public string RaceWiki { get; set; }


        public static RaceWeekend FromCsv(string line)
        {
            var values = line.Split(',');
            var dateParts = values[5].Replace("\"", "").Split('-');
            var timeParts = values[6].Replace("\"", "").Split(':');
            
            using(var db = new F1EncyclopediaContext())
            {
                var track = db.Tracks.FirstOrDefault(x => x.Id == Convert.ToInt16(values[3]));

                if (track == null)
                {
                    Console.WriteLine($"Could not find Track with Id: {values[3]}");
                }

                var raceWeekend = new RaceWeekend
                {
                    Year = Convert.ToInt16(values[1]),
                    Round = Convert.ToInt16(values[2]),
                    TrackId = track != null ? track.Id : 1,
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
}
