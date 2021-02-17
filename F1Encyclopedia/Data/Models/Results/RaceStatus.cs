using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Models.Results
{
    public class RaceStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public F1EncyclopediaContext _context { get; set; }

        public RaceStatus() { }
        public RaceStatus(int id, string status)
        {
            Id = id;
            Status = status;
        }

        public static RaceStatus FromCsv(string line)
        {
            var values = line.Split(',');

            return new RaceStatus(){
                Status = values[1]
            };
        }


        /// <summary>
        ///     When seeding the db using the ergast db CSVs, the constructor ids are not sequential. Correction applied to keep referential accuracy.
        /// </summary>
        /// <param name="id">
        ///     The Constructor identifier to check.
        /// </param>
        /// <returns>
        ///     Corrected constructor identifier.
        /// </returns>
        public static int StatusIdCorrection(string idAsString)
        {
            var id = Convert.ToInt32(idAsString);
            switch (id)
            {
                case > 56:
                    return id -= 2;
                case > 51:
                    return id -= 1;
            }
            return id;
        }
    }
}
