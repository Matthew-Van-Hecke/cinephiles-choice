using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinephilesChoiceAPI.Contracts;
using CinephilesChoiceAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinephilesChoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        IRepositoryWrapper _repo;
        public HomeController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: api/Home
        [HttpGet]
        public ContentResult Get()
        {
            return base.Content("<h1>Welcome to CinephilesChoiceAPI!</h1>", "text/html");
        }

        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Home/5
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
