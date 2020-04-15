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
        void CreateMovieFromJObject(string jsonMovie);
    }
}
