using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinephilesChoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviegoersController : ControllerBase
    {
        // GET: api/Moviegoers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Moviegoers/5
        [HttpGet("{id}", Name = "GetMoviegoer")]
        public string Get(int id)
        {
            return "value";
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
