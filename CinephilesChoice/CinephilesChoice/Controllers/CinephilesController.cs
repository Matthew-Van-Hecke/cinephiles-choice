﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> NavigateToAwards()
        {
            List<Nomination> nominations = await NominationAPI.GetAll();
            List<IGrouping<string, Nomination>> groupedNominations = nominations.GroupBy(n => n.Year).ToList();
            return View(groupedNominations);
        }

        // GET: Cinephile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cinephile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cinephile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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