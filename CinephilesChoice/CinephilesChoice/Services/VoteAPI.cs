using CinephilesChoice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinephilesChoice.Services
{
    public static class VoteAPI
    {
        public static async Task<List<Vote>> GetAll()
        {
            List<Vote> votes;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44366/api/Votes");
                string data = await response.Content.ReadAsStringAsync();
                votes = JsonConvert.DeserializeObject<List<Vote>>(data);
            }
            return votes;
        }
        public static async Task<Vote> GetById(int id)
        {
            Vote vote;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44366/api/Votes/" + id);
                string data = await response.Content.ReadAsStringAsync();
                vote = JsonConvert.DeserializeObject<Vote>(data);
            }
            return vote;
        }
        public static async Task<Vote> GetByIdentityUserIdYearOfNominationAndCategory(string identityUserId, string yearOfNomination, string category)
        {
            List<Vote> votes = await GetAll();
            Moviegoer moviegoer = await MoviegoerAPI.GetByUserId(identityUserId);
            votes = votes.Where(v => v.MoviegoerId == moviegoer.Id).ToList();
            List<Nomination> nominations = await NominationAPI.GetNominationsByYearAndCategoryIncludeMovie(yearOfNomination, category);
            Vote vote = votes.Where(v => nominations.Select(n => n.Id).Contains(v.NominationId) && v.Date.Year == DateTime.Now.Year).FirstOrDefault();
            return vote;
        }
        public static async void Create(Vote vote)
        {
            string voteJson = JsonConvert.SerializeObject(vote).ToString();
            StringContent voteHttp = new StringContent(voteJson, UnicodeEncoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync("https://localhost:44366/api/Votes", voteHttp);
            }
        }
        public static async void Update(Vote vote)
        {
            string voteJson = JsonConvert.SerializeObject(vote);
            StringContent voteHttp = new StringContent(voteJson, UnicodeEncoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsync("https://localhost:44366/api/Votes/" + vote.Id, voteHttp);
            }
        }
        public static async void Delete(Vote vote)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync("https://localhost:44366/api/Votes/" + vote.Id);
            }
        }
    }
}
