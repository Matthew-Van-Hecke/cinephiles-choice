using CinephilesChoiceAPI.Contracts;
using CinephilesChoiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Data
{
    public class NominationRepository : RepositoryBase<Nomination>, INominationRepository
    {
        public NominationRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }

        public IQueryable<Nomination> GetNominations()
        {
            return FindAll();
        }
        public Nomination GetNominationById(int id)
        {
            return FindByCondition(n => n.Id == id).FirstOrDefault();
        }

        public IQueryable<Nomination> GetNominationsByMovieId(int movieId)
        {
            return FindByCondition(n => n.MovieId == movieId);
        }

        public IQueryable<Nomination> GetNominationsByYear(string year)
        {
            return FindByCondition(n => n.Year == year);
        }
    }
}
