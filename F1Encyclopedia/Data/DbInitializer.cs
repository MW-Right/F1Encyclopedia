using F1Encyclopedia.Data.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data
{
    public static class DbInitializer
    {
        public static void Initialize(F1EncyclopediaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Countries.Any())
            {
                return;
            }

            Seed.SeedDb();
        }
    }
}
