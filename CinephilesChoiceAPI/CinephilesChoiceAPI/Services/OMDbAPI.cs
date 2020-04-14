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
        public static async Task<JObject> GetMovie(string movieQuery)
        {
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(@"http://www.omdbapi.com/?apikey=" + movieQuery);
                var data = await response.Content.ReadAsStringAsync();
                JObject movie = JsonConvert.DeserializeObject<JObject>(data);
                return movie;
            }
        }
    }
}
