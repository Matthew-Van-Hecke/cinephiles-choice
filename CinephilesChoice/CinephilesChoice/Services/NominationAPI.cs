using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CinephilesChoice.Models;
using Newtonsoft.Json;

namespace CinephilesChoice.Services
{
    public static class NominationAPI
    {
        public static async Task<List<Nomination>> GetAll()
        {
            List<Nomination> nominations;
            using(HttpClient client = new HttpClient())
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
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44366/api/Nominations/" + id);
                string data = await response.Content.ReadAsStringAsync();
                nomination = JsonConvert.DeserializeObject<Nomination>(data);
            }
            return nomination;
        }
        public static async void Create(Nomination nomination)
        {

        }
        public static async void Update(Nomination nomination)
        {

        }
        public static async void Delete(Nomination nomination)
        {

        }
    }
}
