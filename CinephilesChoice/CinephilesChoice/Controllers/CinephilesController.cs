﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CinephilesChoice.Models;
using CinephilesChoice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinephilesChoice.Controllers
{
    public class CinephilesController : Controller
    {
        // GET: Cinephile
        public async Task<ActionResult> Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Moviegoer moviegoer = await MoviegoerAPI.GetByUserId(userId);
            return View(moviegoer);
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
            List<Nomination> nominations = await NominationAPI.GetNominationsByYearAndCategoryIncludeMovie(year, category);
            return View(nominations);
        }
        public async Task<ActionResult> VoteOnNomination(string year, string category)
        {
            VoteViewModel voteViewModel = new VoteViewModel();
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            voteViewModel.Vote = await VoteAPI.GetByIdentityUserIdYearOfNominationAndCategory(userId, year, category);
            voteViewModel.Nominations = await NominationAPI.GetNominationsByYearAndCategoryIncludeMovie(year, category);
            return View(voteViewModel);
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
                return RedirectToAction(nameof(Index));
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
    }
}