using CinephilesChoiceAPI.Contracts;
using CinephilesChoiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Data
{
    public class RecommendationRepository : RepositoryBase<Recommendation>, IRecommendationRepository
    {
        public RecommendationRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {

        }
    }
}
