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
                var correctedTrackId = Track.TrackIdCorrection(Convert.ToInt16(values[3]));
                var track = db.Tracks.FirstOrDefault(x => x.Id == correctedTrackId);

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
