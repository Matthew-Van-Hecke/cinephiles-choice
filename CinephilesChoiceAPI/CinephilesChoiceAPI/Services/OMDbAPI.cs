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
        public static async Task<JObject> GetMovie(string movieTitle, int year = 0, int attemptNumber = 0)
        {
            string movieQuery = BuildURLStringFromMovieInfo(movieTitle, year);
            JObject movie;
            HttpClient client = new HttpClient();
            
                var response = await client.GetAsync(@"http://www.omdbapi.com/?apikey=" + movieQuery);
                var data = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<JObject>(data);
                if (movie["Response"].ToString() == "False" && year != 0 && attemptNumber < 2)
                {
                    switch (attemptNumber)
                    {
                        case 0:
                            return await GetMovie(movieTitle, (year + 1), (attemptNumber + 1));
                        case 1:
                            return await GetMovie(movieTitle, (year - 2), (attemptNumber + 1));
                    }
                }
            //client.Dispose();
            return movie;
        }
        public static string BuildURLStringFromMovieInfo(string movieTitle, int year)
        {
            string result = "t=" + movieTitle.Replace(' ', '+');
            if (year != 0)
            {
                result += "&y=" + year.ToString();
            }
            result = API_Keys.OMDbAPIKey + "&" + result;
            return result;
        }
    }
}
