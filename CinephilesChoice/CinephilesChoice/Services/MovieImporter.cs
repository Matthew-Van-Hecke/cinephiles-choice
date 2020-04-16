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
            JObject jObjectMovie = await OMDbAPI.GetMovie("Up");
            string json = jObjectMovie.ToString();
            Movie movie = JsonConvert.DeserializeObject<Movie>(json);
            string jsonMovie = JsonConvert.SerializeObject(movie);
            MovieAPI.Create(jsonMovie);
            //_repo.Movie.CreateMovieFromJObject(jsonMovie);
            //_repo.Save();
            //newMovieId = _repo.Movie.FindAll().Last().Id;
        }
    }
}