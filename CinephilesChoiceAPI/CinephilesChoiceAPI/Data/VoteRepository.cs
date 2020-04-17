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

        public IQueryable<Vote> GetAllVotes()
        {
            return FindAll();
        }

        public Vote GetVoteById(int id)
        {
            return FindByCondition(v => v.Id == id).FirstOrDefault();
        }
        public void CreateVote(Vote vote)
        {
            vote.Date = DateTime.Now;
            Create(vote);
        }
    }
}
