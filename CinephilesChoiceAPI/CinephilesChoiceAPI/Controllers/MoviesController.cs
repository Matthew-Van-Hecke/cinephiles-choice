using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinephilesChoiceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinephilesChoiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private ApplicationDbContext _context;
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Movie
            {
                
            })
            .ToArray();
        }
    }
}
