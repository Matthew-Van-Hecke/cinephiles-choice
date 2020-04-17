using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinephilesChoiceAPI.Models;

namespace CinephilesChoiceAPI.Contracts
{
    public interface IRecommendationRepository : IRepositoryBase<Recommendation>
    {
        IQueryable<Recommendation> GetAllRecommendations();
        Recommendation GetRecommendationById(int id);
    }
}
