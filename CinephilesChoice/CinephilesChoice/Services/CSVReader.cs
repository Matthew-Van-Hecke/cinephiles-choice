using CinephilesChoice.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Services
{
    public static class CSVReader
    {
        public static List<CSVEntry> ReadCSV(string csvFilePath)
        {
            string[] lines = File.ReadAllLines(csvFilePath);
            List<CSVEntry> nominations = new List<CSVEntry>();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] lineElements = lines[i].Split(",,");
                CSVEntry nomination = new CSVEntry();
                nomination.Year = int.Parse(lineElements[0]);
                nomination.Category = lineElements[1];
                nomination.IsWinner = bool.Parse(lineElements[2]);
                nomination.Entity = lineElements[3];
                nomination.Film = lineElements[4];
                nominations.Add(nomination);
            };
            return nominations;
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
