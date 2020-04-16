using CinephilesChoice.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinephilesChoice.Services
{
    public static class MovieAPI
    {
        public static async Task<List<Movie>> GetAll()
        {
            List<Movie> movies = new List<Movie>();
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44366/api/Movies");
                string data = await response.Content.ReadAsStringAsync();
                movies = JsonConvert.DeserializeObject<List<Movie>>(data);
            }
            return movies;
        }
        public static async Task<Movie> GetById(int id)
        {
            Movie movie;
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44366/api/Movies/" + id);
                string data = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<Movie>(data);
            }
            return movie;
        }
        public static async void Create(Movie movie)
        {
            string jsonMovie = JsonConvert.SerializeObject(movie);
            using(HttpClient client = new HttpClient())
            {
                StringContent movieHttp = new StringContent(jsonMovie, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:44366/api/Movies", movieHttp);
            }
        }
        public static async void Update(Movie movie)
        {
            string jsonMovie = JsonConvert.SerializeObject(movie);
            using(HttpClient client = new HttpClient())
            {
                StringContent movieHttp = new StringContent(jsonMovie, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("https://localhost:44366/api/Movies/" + movie.Id , movieHttp);
            }
        }
        public static async void Delete(Movie movie)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:44366/api/Movies/" + movie.Id);
            }
        }
    }
}
