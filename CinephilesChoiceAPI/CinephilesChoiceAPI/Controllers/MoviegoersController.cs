using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinephilesChoiceAPI.Contracts;
using CinephilesChoiceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinephilesChoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviegoersController : ControllerBase
    {
        IRepositoryWrapper _repo;
        public MoviegoersController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: api/Moviegoers
        [HttpGet]
        public IEnumerable<Moviegoer> Get()
        {
            return _repo.Moviegoer.GetAllMoviegoers();
        }

        // GET: api/Moviegoers/5
        [HttpGet("{id}", Name = "GetMoviegoer")]
        public Moviegoer Get(string id)
        {
            return _repo.Moviegoer.GetMoviegoerByIdentityUserId(id);
        }

        // POST: api/Moviegoers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Moviegoers/5
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
