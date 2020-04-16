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
    public class MoviesController : ControllerBase
    {
        IRepositoryWrapper _repo;
        public MoviesController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: api/Movie
        [HttpGet]
        public IEnumerable<Movie> Get()
        {

            return _repo.Movie.GetMovies();
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "GetMovie")]
        public Movie Get(int id)
        {
            return _repo.Movie.GetMovieById(id);
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
        public void Put(int id, [FromBody] Movie movie)
        {
            _repo.Movie.Update(movie);
            _repo.Save();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Movie movieToDelete = _repo.Movie.GetMovieById(id);
            _repo.Movie.Delete(movieToDelete);
            _repo.Save();
        }
    }
}
