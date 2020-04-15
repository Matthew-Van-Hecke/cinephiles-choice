using CinephilesChoiceAPI.Contracts;
using CinephilesChoiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Data
{
    public class VoteRepository : RepositoryBase<Vote>, IVoteRepository
    {
        public VoteRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }
    }
}
