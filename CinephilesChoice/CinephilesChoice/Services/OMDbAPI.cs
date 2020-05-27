using CinephilesChoice;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading;

namespace CinephilesChoiceAPI.Services
{
    public static class OMDbAPI
    {
        public static Semaphore semaphore;
        //static OMDbAPI()
        //{
        //    int initCount = 1;
        //    int maxCount = 5;
        //    semaphore = new Semaphore(initCount, maxCount);
        //}
        public static JObject GetMovie(string movieTitle, int year = 0, int attemptNumber = 0)
        {
            //semaphore.WaitOne();
            string movieQuery = BuildURLStringFromMovieInfo(movieTitle, year);
            JObject movie;
            HttpClient client = new HttpClient();

            var response = client.GetAsync(@"http://www.omdbapi.com/?apikey=" + movieQuery).GetAwaiter().GetResult();
            var data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            movie = JsonConvert.DeserializeObject<JObject>(data);
            if (movie["Response"].ToString() == "False" && year != 0 && attemptNumber < 3)
            {
                switch (attemptNumber)
                {
                    case 0:
                        //semaphore.Release();
                        return GetMovie(movieTitle, (year + 1), (attemptNumber + 1));
                    case 1:
                        //semaphore.Release();
                        return GetMovie(movieTitle, (year - 2), (attemptNumber + 1));
                    case 2:
                        movie = new JObject();
                        movie.Add("title", movieTitle);
                        movie.Add("year", year);
                        movie.Add("poster", "/media/NoPoster.jpg");
                        break;
                }
            }
            //semaphore.Release();
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
