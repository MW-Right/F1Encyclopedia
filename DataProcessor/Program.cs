using F1Encyclopedia.Data.Models.Common;
using F1Encyclopedia.Data.Models.Tracks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataProcessor
{
    class Program
    {
        public static string baseLocation = "..\\..\\..\\..\\DataTrawl\\";

        static async Task Main(string[] args)
        {
            // ProcessErgastCountries();
            ProcessErgastTracks();
        }

        public static void ProcessErgastCountries()
        {
            string fileLocation = baseLocation + "countries.csv";
            var data = new List<Country>();
            var headers = new List<string>();

            using (var sr = new StreamReader(fileLocation))
            {
                headers = sr.ReadLine().Split(',').ToList();
                var badHeader = "";
                Console.WriteLine(Country.CheckHeadersCorrect(headers, out badHeader));

                if (Country.CheckHeadersCorrect(headers, out badHeader))
                {
                    data = File.ReadAllLines(fileLocation)
                        .Skip(1)
                        .Select(x => Country.FromCsv(x, headers))
                        .ToList();
                }
                else
                {
                    PropertyException(badHeader, typeof(Country));
                }
            }
        }

        public static void ProcessErgastTracks()
        {
            string fileLocation = baseLocation + "circuits.csv";
            var data = new List<Track>();
            var headers = new List<string>();

            using (var sr = new StreamReader(fileLocation))
            {
                headers = sr.ReadLine().Split(',').ToList();
                var badHeader = "";
                Console.WriteLine(Track.CheckHeadersCorrect(headers, out badHeader));

                if (Track.CheckHeadersCorrect(headers, out badHeader))
                {
                    data = File.ReadAllLines(fileLocation)
                        .Skip(1)
                        .Select(x => Track.FromCsv(x, headers))
                        .ToList();
                }
                else
                {
                    PropertyException(badHeader, typeof(Country));
                }
            }
        }

        public static void PropertyException(string header, Type type)
        {
            throw new Exception($"Header: {header} was not found on object, please check the csv or add a new migration to add the new column to the db.");
        }
        
        // Redundant requests to Ergast API, requested the csv data.
        //public static async Task FetchDriverData(int season)
        //{
        //    var url = $"http://ergast.com/api/f1/{season}/drivers.json";

        //    using (var http = new HttpClient())
        //    {
        //        try
        //        {
        //            using (var response = await http.GetAsync(url))
        //            {
        //                response.EnsureSuccessStatusCode();
        //                var responseBody = await response.Content.ReadAsStringAsync();
                        
        //            }
        //        }
        //        catch(Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //    return new List<Person>();
        //}
    }
}
