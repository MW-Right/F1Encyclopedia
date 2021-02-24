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
            var dateParts = (values[5].Contains('-') ? 
                    values[5].Replace("\"", "").Split('-') :
                    values[5].Replace("\"", "").Split('/'))
                .Select(x => Convert.ToInt32(x))
                .ToList();

            var yearIndex = dateParts.IndexOf(dateParts.Where(x => x.ToString().Length == 4).FirstOrDefault());

            var timePartStrings = values[6].Replace("\"", "")
                .Split(':')
                .ToList();

            var timeParts = new List<int>();

            if (timeParts.Count() == 3)
                timeParts = timePartStrings.Select(x => Convert.ToInt32(x)).ToList();
            
            using(var db = new F1EncyclopediaContext())
            {
                var trackId = Convert.ToInt16(values[3]);
                var track = db.Tracks.FirstOrDefault(x => x.Id == trackId);

                if (track == null)
                {
                    Console.WriteLine($"Could not find Track with Id: {values[3]}");
                }

                var date = new DateTime();

                if (timeParts.Count() == 3)
                {
                    if (yearIndex == 2)
                        date = new DateTime(dateParts[2], dateParts[1], dateParts[0],
                            timeParts[0], timeParts[1], timeParts[2]);
                    else
                        date = new DateTime(dateParts[0],dateParts[1],dateParts[2],
                            timeParts[0],timeParts[1],timeParts[2]);
                }
                else
                {
                    if (yearIndex == 2)
                        date = new DateTime(dateParts[2],dateParts[1],dateParts[0]);
                    else
                        date = new DateTime(dateParts[0],dateParts[1],dateParts[2]);
                }

                var raceWeekend = new RaceWeekend
                {
                    Id = Convert.ToInt16(values[0]),
                    Year = Convert.ToInt16(values[1]),
                    Round = Convert.ToInt16(values[2]),
                    TrackId = track != null ? track.Id : 1,
                    Name = values[4].Replace("\"", ""),
                    Date = date,
                    RaceWiki = values[7].Replace("\"", "")
                };

                return raceWeekend;
            }
        }

        /// <summary>
        ///     When seeding the db using the ergast db CSVs, the RaceWeekend ids are not sequential. Correction applied to keep referential accuracy.
        /// </summary>
        /// <param name="id">
        ///     The RaceWeekend identifier to check.
        /// </param>
        /// <returns>
        ///     Corrected RaceWeekend identifier.
        /// </returns>
        public static int RaceWeekendIdCorrection(string stringId)
        {
            var id = Convert.ToInt32(stringId);

            switch(id)
            {
                case > 1047:
                    return id -= 16;
                case > 945:
                    return id -= 13;
                case > 918:
                    return id -= 9;
                case > 888:
                    return id -= 2;
                case > 840:
                    return id -= 1;
            }
            return id;
        }
    }
}
