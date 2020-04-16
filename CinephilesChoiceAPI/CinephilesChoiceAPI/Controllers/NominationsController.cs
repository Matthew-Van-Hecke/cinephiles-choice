using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinephilesChoiceAPI.Contracts;
using CinephilesChoiceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CinephilesChoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominationsController : ControllerBase
    {
        IRepositoryWrapper _repo;
        public NominationsController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: api/Nominations
        [HttpGet]
        public IEnumerable<Nomination> Get()
        {
            return _repo.Nomination.GetNominations();
        }

        // GET: api/Nominations/5
        [HttpGet("{id}", Name = "GetNomination")]
        public Nomination Get(int id)
        {
            return _repo.Nomination.GetNominationById(id);
        }

        // POST: api/Nominations
        [HttpPost]
        public void Post([FromBody] Nomination nomination)
        {
            //Nomination nominationToAdd = JsonConvert.DeserializeObject<Nomination>(nominationJson);
            _repo.Nomination.Create(nomination);
            _repo.Save();
        }

        // PUT: api/Nominations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Nomination nomination)
        {
            _repo.Nomination.Update(nomination);
            _repo.Save();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Nomination nomination = _repo.Nomination.GetNominationById(id);
            _repo.Nomination.Delete(nomination);
            _repo.Save();
        }
    }
}
