﻿using CinephilesChoiceAPI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Services
{
    public class MovieImporter
    {
        private IRepositoryWrapper _repo;
        public MovieImporter(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public async void ImportMovies()
        {
            int newMovieId;
            JObject jObjectMovie = await OMDbAPI.GetMovie("A Sister");
            string jsonMovie = jObjectMovie.ToString();
            _repo.Movie.CreateMovieFromJObject(jsonMovie);
            _repo.Save();
            newMovieId = _repo.Movie.FindAll().Last().Id;
        }
    }
}
