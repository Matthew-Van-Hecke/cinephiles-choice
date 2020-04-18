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
    public static class MoviegoerAPI
    {
        public static async Task<List<Moviegoer>> GetAll()
        {
            List<Moviegoer> moviegoers = new List<Moviegoer>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44366/api/Moviegoers");
                string data = await response.Content.ReadAsStringAsync();
                moviegoers = JsonConvert.DeserializeObject<List<Moviegoer>>(data);
            }
            return moviegoers;
        }
        public static async Task<Moviegoer> GetByUserId(string id)
        {
            Moviegoer moviegoer;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44366/api/Moviegoers/" + id);
                string data = await response.Content.ReadAsStringAsync();
                moviegoer = JsonConvert.DeserializeObject<Moviegoer>(data);
            }
            return moviegoer;
        }
        public static async void Create(Moviegoer moviegoer)
        {
            string jsonMoviegoer = JsonConvert.SerializeObject(moviegoer);
            using (HttpClient client = new HttpClient())
            {
                StringContent moviegoerHttp = new StringContent(jsonMoviegoer, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:44366/api/Moviegoers", moviegoerHttp);
            }
        }
        public static async void Update(Moviegoer moviegoer)
        {
            string jsonMoviegoer = JsonConvert.SerializeObject(moviegoer);
            using (HttpClient client = new HttpClient())
            {
                StringContent moviegoerHttp = new StringContent(jsonMoviegoer, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("https://localhost:44366/api/Moviegoers/" + moviegoer.Id, moviegoerHttp);
            }
        }
        public static async void Delete(Movie moviegoer)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:44366/api/Moviegoers/" + moviegoer.Id);
            }
        }
    }
}
