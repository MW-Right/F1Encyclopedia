using F1Encyclopedia.Data.Models.Common;
using System.Collections.Generic;

namespace F1Encyclopedia.Data.Models.Tracks
{
    public class Track : F1Table
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

        public Track() : base() { }

        public static bool CheckHeadersCorrect(List<string> headers, out string badHeader)
        {
            return F1Table.CheckHeadersCorrect(headers, typeof(Track), out badHeader);
        }

        public static Track FromCsv(string line, List<string> headers)
        {
            var values = line.Split(',');
            var track = new Track();

            return F1Table.FromCsv(values, headers, track);
        }
    }
}
