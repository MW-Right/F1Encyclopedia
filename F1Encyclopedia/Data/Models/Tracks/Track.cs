using F1Encyclopedia.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace F1Encyclopedia.Data.Models.Tracks
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }
        public int Alt { get; set; }
        public string WikiUrl { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public Track() { }


        public static Track FromCsv(string line)
        {
            var values = line.Split(',');
            using (var db = new F1EncyclopediaContext())
            {
                if (values[3] == "UK")
                {
                    values[3] = "United Kingdom";
                }

                var country = db.Countries.FirstOrDefault(x => x.Name == values[3]);

                if (country == null)
                {
                    Console.WriteLine($"Could not find country with name: {values[3]}");
                }

                var track = new Track()
                {
                    Id = Convert.ToInt16(values[0]),
                    Name = values[1],
                    City = values[2],
                    CountryId = country != null ? country.Id : 1,
                    Lat = Convert.ToSingle(values[4]),
                    Long = Convert.ToSingle(values[5]),
                    Alt = Convert.ToInt16(values[6]),
                    WikiUrl = values[7]
                };

                return track;
            }
        }

        /// <summary>
        ///     When seeding the db using the ergast db csvs, the track ids are not sequential. Correction applied to keep referential accuracy.
        /// </summary>
        /// <param name="id">
        ///     The Track identifier to check.
        /// </param>
        /// <returns>
        ///     Corrected Track identifier.
        /// </returns>
        public static int TrackIdCorrection(int id)
        {
            // Ids are sequential in current data. Edit here if changing.
            return id;
        }
    }
}
