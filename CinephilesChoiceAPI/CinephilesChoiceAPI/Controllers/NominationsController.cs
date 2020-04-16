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
    public class NominationsController : ControllerBase
    {
        // GET: api/Nominations
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Nominations/5
        [HttpGet("{id}", Name = "GetNomination")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Nominations
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Nominations/5
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
