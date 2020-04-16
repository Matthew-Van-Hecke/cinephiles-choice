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
    public static class MovieAPI
    {
        public static void GetAll()
        {

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
                var response = await client.PostAsync("https://localhost:44366/api/Movie", movieHttp);
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
