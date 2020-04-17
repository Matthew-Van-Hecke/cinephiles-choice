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
    public class RecommendationsController : ControllerBase
    {
        IRepositoryWrapper _repo;
        public RecommendationsController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: api/Recommendations
        [HttpGet]
        public IEnumerable<Recommendation> Get()
        {
            return _repo.Recommendation.GetAllRecommendations();
        }

        // GET: api/Recommendations/5
        [HttpGet("{id}", Name = "GetRecommendation")]
        public Recommendation Get(int id)
        {
            return _repo.Recommendation.GetRecommendationById(id);
        }

        // POST: api/Recommendations
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Recommendations/5
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
