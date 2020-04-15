using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Services
{
    public static class OMDbAPI
    {
        public static async Task<JObject> GetMovie(string movieTitle)
        {
            string movieQuery = "";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(@"http://www.omdbapi.com/?apikey=" + movieQuery);
                var data = await response.Content.ReadAsStringAsync();
                JObject movie = JsonConvert.DeserializeObject<JObject>(data);
                return movie;
            }
        }
        //public string BuildURLStringFromMovieInfo(string movieTitle, int year = 0)
        //{
        //    string result = "t=" + movieTitle.Replace(' ', '+');
        //    if (year != 0)
        //    {
        //        result += "y=" + year.ToString();
        //    }
        //    result = API_Keys.OMDbAPIKey + result;
        //    return result;
        //}
    }
}
