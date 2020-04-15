using CinephilesChoiceAPI.Contracts;
using CinephilesChoiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Data
{
    public class MoviegoerRepository : RepositoryBase<Moviegoer>, IMoviegoerRepository
    {
        public MoviegoerRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }
    }
}
