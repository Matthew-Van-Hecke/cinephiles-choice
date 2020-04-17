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
    public class VotesController : ControllerBase
    {
        IRepositoryWrapper _repo;
        public VotesController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: api/Votes
        [HttpGet]
        public IEnumerable<Vote> Get()
        {
            return _repo.Vote.FindAll();
        }

        // GET: api/Votes/5
        [HttpGet("{id}", Name = "GetVote")]
        public Vote Get(int id)
        {
            return _repo.Vote.GetVoteById(id);
        }

        // POST: api/Votes
        [HttpPost]
        public void Post([FromBody] Vote vote)
        {
            _repo.Vote.CreateVote(vote);
            _repo.Save();
        }

        // PUT: api/Votes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vote vote)
        {
            _repo.Vote.UpdateVote(vote);
            _repo.Save();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Vote vote = _repo.Vote.GetVoteById(id);
            _repo.Vote.Delete(vote);
            _repo.Save();
        }
    }
}
