using CinephilesChoiceAPI.Contracts;
using CinephilesChoiceAPI.Data;
using CinephilesChoiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IMoviegoerRepository _moviegoer;
        private IMovieRepository _movie;
        private INominationRepository _nomination;
        private IRecommendationRepository _recommendation;
        private IVoteRepository _vote;
        public IMoviegoerRepository Moviegoer
        {
            get
            {
                if(_moviegoer == null)
                {
                    _moviegoer = new MoviegoerRepository(_context);
                }
                return _moviegoer;
            }
        }
        public IMovieRepository Movie
        {
            get
            {
                if(_movie == null)
                {
                    _movie = new MovieRepository(_context);
                }
                return _movie;
            }
        }
        public INominationRepository Nomination
        {
            get
            {
                if(_nomination == null)
                {
                    _nomination = new NominationRepository(_context);
                }
                return _nomination;
            }
        }
        public IRecommendationRepository Recommendation
        {
            get
            {
                if(_recommendation == null)
                {
                    _recommendation = new RecommendationRepository(_context);
                }
                return _recommendation;
            }
        }
        public IVoteRepository Vote
        {
            get
            {
                if(_vote == null)
                {
                    _vote = new VoteRepository(_context);
                }
                return _vote;
            }
        }
        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
