using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Contracts
{
    public interface IRepositoryWrapper
    {
        IMoviegoerRepository Moviegoer { get; }
        IMovieRepository Movie { get; }
        INominationRepository Nomination { get; }
        IRecommendationRepository Recommendation { get; }
        IVoteRepository Vote { get; }
        void Save();
    }
}
