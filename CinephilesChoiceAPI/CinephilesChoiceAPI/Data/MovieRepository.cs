using CinephilesChoiceAPI.Contracts;
using CinephilesChoiceAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Data
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            
        }
        public void CreateMovieFromJObject(string jsonMovie)
        {
            Movie movie = JsonConvert.DeserializeObject<Movie>(jsonMovie);
            //Movie movie = new Movie();
            Create(movie);
        }
    }
}
