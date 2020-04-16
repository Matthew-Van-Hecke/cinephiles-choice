using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinephilesChoiceAPI.Contracts;
using CinephilesChoiceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CinephilesChoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IRepositoryWrapper _repo;
        public MovieController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: api/Movie
        [HttpGet]
        public IEnumerable<Movie> Get()
        {

            return _repo.Movie.FindAll();
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "GetMovie")]
        public Movie Get(int id)
        {
            return _repo
        }

        // POST: api/Movie
        [HttpPost]
        public void Post([FromBody] Movie movie)
        {
            Movie movieFromDb = _repo.Movie.FindByCondition(m => m.Title == movie.Title && m.Year == movie.Year).FirstOrDefault();
            if (movieFromDb == null)
            {
                _repo.Movie.Create(movie);
                _repo.Save();
            }
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
