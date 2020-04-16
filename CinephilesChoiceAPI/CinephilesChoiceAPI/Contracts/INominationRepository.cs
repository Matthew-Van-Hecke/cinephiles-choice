using CinephilesChoiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Contracts
{
    public interface INominationRepository : IRepositoryBase<Nomination>
    {
        IQueryable<Nomination> GetNominations();
        Nomination GetNominationById(int id);
        IQueryable<Nomination> GetNominationsByYear(string year);
        IQueryable<Nomination> GetNominationsByMovieId(int movieId);
    }
}
