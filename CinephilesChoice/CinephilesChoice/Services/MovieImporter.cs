using CinephilesChoice.Models;
using CinephilesChoice.Services;
using CinephilesChoiceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Services
{
    public static class MovieImporter
    {
        public static async void ImportMovies()
        {
            List<CSVEntry> moviesFromCsv = CSVReader.ReadCSV(@"../../../oscar_nominees_csv.csv");
            foreach(CSVEntry entry in moviesFromCsv)
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
            }
            string jsonMovie = JsonConvert.SerializeObject(movie);
            MovieAPI.Create(jsonMovie);
        }
    }
}