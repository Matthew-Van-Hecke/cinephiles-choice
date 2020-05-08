using CinephilesChoice.Models;
using System.Collections.Generic;

namespace CinephilesChoice.Services
{
    public static class NominationImporter
    {
        public static void ImportNominations(string filePath)
        {
            List<CSVEntry> lines = CSVReader.ReadCSV(filePath);
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
