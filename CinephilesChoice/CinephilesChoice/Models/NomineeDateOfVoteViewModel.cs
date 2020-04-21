using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Models
{
    public class NomineeDateOfVoteViewModel
    {
        public NomineeDateOfVoteViewModel(int yearOfVote, string movieTitle)
        {
            YearOfVote = yearOfVote;
            MovieTitle = movieTitle;
        }
        public int YearOfVote { get; }
        public string MovieTitle { get; }
    }
}
