using CinephilesChoice.Models;
using CinephilesChoice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinephilesChoice.Controllers
{
    public class AdminsController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        public AdminsController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        // GET: Admin
        public async Task<ActionResult> Index()
        {
            List<Moviegoer> moviegoers = await MoviegoerAPI.GetAll();
            return View(moviegoers);
        }

        // GET: Admin/Details/5
        public async Task<ActionResult> MoviegoerDetails(int id)
        {
            List<Moviegoer> moviegoers = await MoviegoerAPI.GetAll();
            Moviegoer moviegoer = moviegoers.Where(m => m.Id == id).FirstOrDefault();
            return View(moviegoer);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public async Task<ActionResult> EditMoviegoer(int id)
        {
            List<Moviegoer> moviegoers = await MoviegoerAPI.GetAll();
            MoviegoerViewModel viewModel = new MoviegoerViewModel();
            viewModel.Moviegoer = moviegoers.Where(m => m.Id == id).First();
            List<KeyValuePair<string, string>> rolesList = _roleManager.Roles.Select(r => new KeyValuePair<string, string>(r.Id, r.Name)).ToList();
            viewModel.RoleManager = new Dictionary<string, string>();
            foreach(KeyValuePair<string, string> role in rolesList)
            {
                viewModel.RoleManager.Add(role.Key, role.Value);
            }
            return View(viewModel);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMoviegoer(int id, MoviegoerViewModel moviegoerViewModel)
        {
            try
            {
                MoviegoerAPI.Update(moviegoerViewModel.Moviegoer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
        public ActionResult ImportNominations()
        {
            return View();
        }
        public ActionResult AddMoviesAndNominationsToDatabase(ImportNominationsViewModel viewModel)
        {
            try
            {
                MovieImporter.ImportMovies(viewModel.FilePath);
                NominationImporter.ImportNominations(viewModel.FilePath);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(ImportNominations));
            }
        }
        public async Task<ActionResult> ListMovies()
        {
            List<Movie> movies = await MovieAPI.GetAll();
            return View(movies);
        }
        public async Task<ActionResult> MovieDetails(int id)
        {
            Movie movie = await MovieAPI.GetById(id);
            return View(movie);
        }
        public async Task<ActionResult> EditMovie(int id)
        {
            Movie movie = await MovieAPI.GetById(id);
            return View(movie);
        }
        [HttpPost]
        public ActionResult EditMovie(Movie editedMovie)
        {
            MovieAPI.Update(editedMovie);
            return RedirectToAction(nameof(MovieDetails), editedMovie);
        }
    }
}