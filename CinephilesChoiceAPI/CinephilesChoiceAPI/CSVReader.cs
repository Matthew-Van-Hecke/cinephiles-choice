using CinephilesChoiceAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI
{
    public static class CSVReader
    {
        public static List<JObject> ReadCSV(string csvFilePath)
        {
            string[] lines = File.ReadAllLines(@"../../../oscar_nominees_csv.csv");

            return new List<JObject>();
        }
        //private static Nomination BuildNominationFromCSVLine(string csvLine)
        //{
        //    Nomination nomination = new Nomination();
        //    Movie movie = new Movie();
        //    string[] data = csvLine.Split(",,");
        //    movie.Year = int.Parse(data[0]);
        //    nomination.AwardCategory = data[1];
        //}
    }
}
