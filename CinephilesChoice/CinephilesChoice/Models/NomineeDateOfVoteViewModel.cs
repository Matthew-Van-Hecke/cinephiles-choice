using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Models
{
    public class NomineeDateOfVoteViewModel
    {
        public NomineeDateOfVoteViewModel(int yearOfVote, string nominee)
        {
            YearOfVote = yearOfVote;
            Nominee = nominee;
        }
        public int YearOfVote { get; }
        public string Nominee { get; }
    }
}
