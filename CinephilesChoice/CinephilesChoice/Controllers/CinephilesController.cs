﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CinephilesChoice.Models;
using CinephilesChoice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CinephilesChoice.Controllers
{
    public class CinephilesController : Controller
    {
        // GET: Cinephile
        public async Task<ActionResult> Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Moviegoer moviegoer = await MoviegoerAPI.GetByUserId(userId);
            if (moviegoer == null)
            {
                return RedirectToAction(nameof(CreateMoviegoer));
            }
            return View(moviegoer);
        }
        public ActionResult IndexWithMoviegoerParameter(Moviegoer moviegoer)
        {
            return View("index", moviegoer);
        }
        public async Task<ActionResult> NavigateToAwards()
        {
            List<Nomination> nominations = await NominationAPI.GetAll();
            foreach(Nomination nomination in nominations)
            {
                nomination.Movie = await MovieAPI.GetById(nomination.MovieId);
            }
            List<IGrouping<string, Nomination>> nominationsGroupedByYear = nominations.GroupBy(n => n.Year).ToList();
            List<List<IGrouping<string, Nomination>>> groupedNominations = nominationsGroupedByYear.Select(g => g.GroupBy(n => n.AwardCategory).ToList()).ToList();
            return View(groupedNominations);
        }
        public async Task<ActionResult> DisplayNominations(string year, string category)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("DisplayNominations", "Home", new YearCategoryModel(year, category));
            }
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Moviegoer moviegoer = await MoviegoerAPI.GetByUserId(userId);
            List<Vote> myVotes = await VoteAPI.GetByIdentityUserIdYearOfNominationAndCategory(userId, year, category);
            bool hasVotedThisYear = myVotes.Where(v => v.Date.Year == DateTime.Now.Year).FirstOrDefault() != null;
            if (!hasVotedThisYear)
            {
                return RedirectToAction(nameof(VoteOnNomination), new YearCategoryModel(year, category));
            }
            NominationViewModel nominationViewModel = await CreateNominationViewModel(year, category);
            nominationViewModel.JsonVotes = JsonDataBuilder.CreateJsonVoteCollection(nominationViewModel);
            nominationViewModel.JsonNomineeNames = JsonDataBuilder.CreateJsonStringFromStringList(nominationViewModel.Nominations.Select(n => n.Nominee).ToList());
            nominationViewModel.MyVotes = await VoteAPI.GetByIdentityUserIdYearOfNominationAndCategory(userId, year, category);
            return View(nominationViewModel);
        }
        
        public async Task<ActionResult> VoteOnNomination(string year, string category)
        {
            VoteViewModel voteViewModel = new VoteViewModel();
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Vote> myVotes = await VoteAPI.GetByIdentityUserIdYearOfNominationAndCategory(userId, year, category);
            voteViewModel.Vote = myVotes.Where(v => v.Date.Year == DateTime.Now.Year).FirstOrDefault();
            if (voteViewModel.Vote == null)
            {
                voteViewModel.Vote = await CreateNewVote(userId);
            }
            voteViewModel.Nominations = await NominationAPI.GetNominationsByYearAndCategoryIncludeMovie(year, category);
            return View(voteViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> VoteOnNomination(VoteViewModel voteViewModel)
        {
            if(voteViewModel.Vote.Id != 0)
            {
                VoteAPI.Update(voteViewModel.Vote);
            }
            else if(voteViewModel.Vote.Id == 0)
            {
                VoteAPI.Create(voteViewModel.Vote);
            };
            Nomination nomination = await NominationAPI.GetById(voteViewModel.Vote.NominationId);
            YearCategoryModel returnParameters = new YearCategoryModel(nomination.Year, nomination.AwardCategory);
            Nomination nominationVotedFor = await NominationAPI.GetById(voteViewModel.Vote.NominationId);
            RecommendationViewModel recommendationViewModel = new RecommendationViewModel()
            {
                Year = nominationVotedFor.Year,
                Category = nominationVotedFor.AwardCategory
            };
            recommendationViewModel.Movie = await MovieAPI.GetById(nominationVotedFor.MovieId);
            recommendationViewModel.MovieId = recommendationViewModel.Movie.Id;
            return RedirectToAction(nameof(MovieRecommendation), recommendationViewModel);
        }
        public async Task<ActionResult> MovieRecommendation(string year, string category, int? movieId)
        {
            Movie movie = await MovieAPI.GetById(movieId.Value);
            List<Movie> movies = await MovieAPI.GetAll();
            movies = movies.Where(m => m.Actors != null).ToList();
            Dictionary<Movie, int> movieRecommendations = BuildMovieDictionary(movies);
            RecommendationViewModel recommendation = new RecommendationViewModel()
            {
                Year = year,
                Category = category
            };
            recommendation.Movie = movies.Where(m => m.Director == movie.Director && m.Title != movie.Title).FirstOrDefault();
            if(recommendation.Movie == null)
            {
                recommendation.Movie = movies.Where(m => CheckIfTwoStringArraysHaveAnElementInCommon(m.Genre.Split(", "), movie.Genre.Split(", ")) && m.Title != movie.Title).FirstOrDefault();
            }
            if(recommendation.Movie == null)
            {
                recommendation.Movie = movies.Where(m => CheckIfTwoStringArraysHaveAnElementInCommon(m.Actors.Split(", "), movie.Actors.Split(", ")) && m.Title != movie.Title).FirstOrDefault();
            }
            if(recommendation.Movie == null)
            {
                recommendation.Movie = movies.Where(m => m.Year == movie.Year && m.Id != movie.Id).FirstOrDefault();
            }
            return View(recommendation);
        }
        // GET: Cinephile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cinephile/Create
        public ActionResult CreateMoviegoer()
        {
            Moviegoer moviegoer = new Moviegoer()
            {
                IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            return View(moviegoer);
        }

        // POST: Cinephile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMoviegoer(Moviegoer moviegoer)
        {
            try
            {
                MoviegoerAPI.Create(moviegoer);
                return RedirectToAction(nameof(IndexWithMoviegoerParameter), moviegoer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Cinephile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cinephile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cinephile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cinephile/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private async Task<Vote> CreateNewVote(string userId)
        {
            Moviegoer moviegoer = await MoviegoerAPI.GetByUserId(userId);
            Vote vote = new Vote()
            {
                MoviegoerId = moviegoer.Id,
                Moviegoer = moviegoer
            };
            return vote;
        }
        private async Task<NominationViewModel> CreateNominationViewModel(string year, string category)
        {
            NominationViewModel nominationViewModel;
            try
            {
                int yearInt = int.Parse(year);
                nominationViewModel = new NominationViewModel()
                {
                    Nominations = await NominationAPI.GetNominationsByYearAndCategoryIncludeMovie(year, category),
                    Votes = await VoteAPI.GetVotesByYearOfNominationAndCategory(year, category),
                    Year = yearInt,
                    Category = category
                };
            }
            catch
            {
                nominationViewModel = null;
            }
            return nominationViewModel;
        }
        private Dictionary<Movie, int> BuildMovieDictionary(List<Movie> movies)
        {
            Dictionary<Movie, int> movieDictionary = new Dictionary<Movie, int>();
            foreach(Movie movie in movies)
            {
                movieDictionary.Add(movie, 0);
            }
            return movieDictionary;
        }
        private bool CheckIfTwoStringArraysHaveAnElementInCommon(string[] arrayOne, string[] arrayTwo)
        {
            foreach(string itemOne in arrayOne)
            {
                foreach(string itemTwo in arrayTwo)
                {
                    if(itemOne == itemTwo)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}