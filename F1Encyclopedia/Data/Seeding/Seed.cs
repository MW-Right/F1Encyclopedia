using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.Seeding
{
    public interface Seed
    {
        public static string baseLocation = "..\\DataTrawl\\";

        public static void PropertyException(string header)
        {
            throw new Exception($"Header: {header} was not found on object, please check the csv or add a new migration to add the new column to the db.");
        }

        public static string UpdateNationalities(string nat)
        {
            switch (nat)
            {
                case "Rhodesian":
                    {
                        nat = "Zimbabwean";
                        break;
                    }
                case "East German":
                    {
                        nat = "German";
                        break;
                    }
                case "Argentine-Italian":
                    {
                        nat = "Argentine";
                        break;
                    }
                case "American-Italian":
                    {
                        nat = "American";
                        break;
                    }
                default: break;
            }
            return nat;
        }

        public static void EnsureCleanDb()
        {
            using (var context = new F1EncyclopediaContext())
            {
                context.CleanTable("RaceResults");
                context.CleanTable("LapTimes");
                context.CleanTable("RaceStatuses");
                context.CleanTable("Qualifyings");
                context.CleanTable("Constructors");
                context.CleanTable("RaceWeekends");
                context.CleanTable("Drivers");
                context.CleanTable("Tracks");
                context.CleanTable("Countries");
            }
        }

        public static void SeedDb()
        {
            EnsureCleanDb();
            SeedCountries.ProcessErgastCountries();
            SeedTracks.ProcessErgastTracks();
            SeedDrivers.ProcessErgastDrivers();
            SeedRaceWeekends.ProcessErgastRaceWeekends();
            SeedConstructors.ProcessErgastConstructors();
            SeedQualifyingResults.ProcessErgastQualifying();
            SeedRaceStatuses.ProcessErgastRaceStatus();
            SeedLapTimes.ProcessErgastLapTimes();
            SeedRaceResults.ProcessErgastRaceResults();
        }

        public static void AddWithIdentityInsert(string tableName, IDbContextTransaction transaction, F1EncyclopediaContext db)
        {
            Debug.WriteLine("\nEntities added and tracked, saving changes...");
            db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT dbo.{tableName} ON");
            db.SaveChanges();
            db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT dbo.{tableName} OFF");
            Debug.WriteLine("Completed.\n\n\n\n");
            transaction.Commit();
        }

        public static void AddWithoutIdentityInsert(IDbContextTransaction transaction, F1EncyclopediaContext db)
        {
            Debug.WriteLine("\nEntities added and tracked, saving changes...");
            db.SaveChanges();
            Debug.WriteLine("Completed.\n\n\n\n");
            transaction.Commit();
        }
    }
}
