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

        public List<RaceStatus> RaceStatuses = new List<RaceStatus>()
        {
            new RaceStatus(1, "Finished"),
            new RaceStatus(2, "Collision"),
            new RaceStatus(3, "Engine"),
            new RaceStatus(4, "Lapped"),
            new RaceStatus(5, "DriverMistake")
        };

        public Task SeedRaceStatuses()
        {
            using (var db = new F1EncyclopediaContext())
            {
                if (!db.RaceStatuses.SequenceEqual(RaceStatuses))
                {
                    foreach (var status in RaceStatuses)
                    {
                        var s = db.RaceStatuses.FirstOrDefault(x => x.Id == status.Id && x.Status == status.Status);
                        
                        if (s == null)
                        {
                            db.RaceStatuses.Add(status);
                        }
                        else
                        {
                            s = status;
                            db.RaceStatuses.Update(s);
                        }
                    }
                }
                return db.SaveChangesAsync();
            }
        }
    }
}
