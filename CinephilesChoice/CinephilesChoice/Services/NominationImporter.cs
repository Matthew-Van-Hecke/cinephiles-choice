using CinephilesChoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Services
{
    public static class NominationImporter
    {
        public static void ImportNominations()
        {
            List<CSVEntry> lines = CSVReader.ReadCSV("../../../oscar_nominees_csv.csv");
            foreach (CSVEntry entry in lines)
            {
                Nomination nomination = new Nomination();
                nomination.Nominee = entry.Entity;
                //if (MovieAPI.GetByTitleSync(entry.Film) != null)
                //{
                    nomination.MovieId = MovieAPI.GetByTitleSync(entry.Film).Id;
                //}
                nomination.AwardCategory = entry.Category;
                nomination.IsWinner = entry.IsWinner;
                nomination.Year = entry.Year.ToString();
                NominationAPI.CreateSync(nomination);
            }
        }
    }
}
