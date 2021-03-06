﻿using CinephilesChoice.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinephilesChoice.Services
{
    public static class NominationAPI
    {
        public static async Task<List<Nomination>> GetAll()
        {
            List<Nomination> nominations;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44366/api/Nominations");
                string data = await response.Content.ReadAsStringAsync();
                nominations = JsonConvert.DeserializeObject<List<Nomination>>(data);
            }
            return nominations;
        }
        public static async Task<Nomination> GetById(int id)
        {
            Nomination nomination = new Nomination();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44366/api/Nominations/" + id);
                string data = await response.Content.ReadAsStringAsync();
                nomination = JsonConvert.DeserializeObject<Nomination>(data);
            }
            nomination.Movie = await MovieAPI.GetById(nomination.MovieId);
            return nomination;
        }
        public static async Task<List<Nomination>> GetNominationsByYearAndCategoryIncludeMovie(string year, string category)
        {
            List<Nomination> allNominations = await NominationAPI.GetAll();
            List<Nomination> nominations = allNominations.Where(n => n.Year == year && n.AwardCategory == category).ToList();
            foreach (Nomination nomination in nominations)
            {
                nomination.Movie = await MovieAPI.GetById(nomination.MovieId);
            }
            return nominations;
        }
        public static async void Create(Nomination nomination)
        {
            string nominationJson = JsonConvert.SerializeObject(nomination).ToString();
            StringContent nominationHttp = new StringContent(nominationJson, UnicodeEncoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync("https://localhost:44366/api/Nominations", nominationHttp);
            }
        }
        public static void CreateSync(Nomination nomination)
        {
            string nominationJson = JsonConvert.SerializeObject(nomination).ToString();
            StringContent nominationHttp = new StringContent(nominationJson, UnicodeEncoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync("https://localhost:44366/api/Nominations", nominationHttp).GetAwaiter().GetResult();
            }
        }
        public static async void Update(Nomination nomination)
        {
            string nominationJson = JsonConvert.SerializeObject(nomination);
            StringContent nominationHttp = new StringContent(nominationJson, UnicodeEncoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsync("https://localhost:44366/api/Nominations/" + nomination.Id, nominationHttp);
            }
        }
        public static async void Delete(Nomination nomination)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync("https://localhost:44366/api/Nominations/" + nomination.Id);
            }
        }
        public static async Task<List<KeyValuePair<string, string>>> GetAllYearCategoryCombinations()
        {
            List<Nomination> nominations = await GetAll();
            nominations = nominations.OrderBy(n => int.Parse(n.Year)).ToList();
            List<KeyValuePair<string, string>> yearCategoryCombinations = nominations.Select(n => new KeyValuePair<string, string>(n.Year, n.AwardCategory)).ToList();
            return yearCategoryCombinations.Distinct().ToList();
        }
    }
}
