using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinephilesChoice.Models;
using CinephilesChoice.Services;

namespace CinephilesChoice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<ActionResult> DisplayNominations(string year, string category)
        {
            NominationViewModel nominationViewModel = await CreateNominationViewModel(year, category);
            nominationViewModel.JsonVotes = JsonDataBuilder.CreateJsonVoteCollection(nominationViewModel);
            nominationViewModel.JsonNomineeNames = JsonDataBuilder.CreateJsonStringFromStringList(nominationViewModel.Nominations.Select(n => n.Nominee).ToList());
            return View(nominationViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
    }
}
