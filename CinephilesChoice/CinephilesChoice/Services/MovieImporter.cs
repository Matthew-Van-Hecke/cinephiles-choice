using CinephilesChoice.Models;
using CinephilesChoiceAPI.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CinephilesChoice.Services
{
    public static class MovieImporter
    {
        public static async void ImportMovies(string filePath)
        {
            List<CSVEntry> moviesFromCsv = CSVReader.ReadCSV(filePath);
            foreach (CSVEntry entry in moviesFromCsv)
            {
                SendMovie(entry.Film, entry.Year);
            }
            //_repo.Movie.CreateMovieFromJObject(jsonMovie);
            //_repo.Save();
            //newMovieId = _repo.Movie.FindAll().Last().Id;
        }
        public static async void SendMovie(string title, int year)
        {
            JObject jObjectMovie = OMDbAPI.GetMovie(title, year);
            string json = jObjectMovie.ToString();
            Movie movie = JsonConvert.DeserializeObject<Movie>(json);
            if (movie != null && movie.Year != null)
            {
                movie.Year = movie.Year.Substring(0, 4);
                Console.WriteLine(movie.Title + " added");
            }
            //string jsonMovie = JsonConvert.SerializeObject(movie);
            MovieAPI.Create(movie);
        }
    }
}