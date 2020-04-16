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
        public static void GetById(int id)
        {

        }
        public static async void Create(string jsonMovie)
        {
            //Movie movie = JsonConvert.DeserializeObject<Movie>(jsonMovie);
            //string movieString = JsonConvert.SerializeObject(movie);
            using(HttpClient client = new HttpClient())
            {
                StringContent movieHttp = new StringContent(jsonMovie, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:44366/api/Movies", movieHttp);
            }
        }
        public static void Update(Movie movie)
        {

        }
        public static void Delete(Movie movie)
        {

        }
    }
}
