using CinephilesChoiceAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Contracts
{
    public interface IMovieRepository : IRepositoryBase<Movie>
    {
        IQueryable<Movie> GetMovies();
        Movie GetMovieById(int id);
        IQueryable<Movie> GetMoviesByTitle(string title);
        void CreateMovieFromJObject(string jsonMovie);
    }
}
