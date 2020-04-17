using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinephilesChoiceAPI.Models;

namespace CinephilesChoiceAPI.Contracts
{
    public interface IVoteRepository : IRepositoryBase<Vote>
    {
        IQueryable<Vote> GetAllVotes();
        Vote GetVoteById(int id);
        void CreateVote(Vote vote);
    }
}
