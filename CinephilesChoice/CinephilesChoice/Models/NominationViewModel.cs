using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Models
{
    public class NominationViewModel
    {
        public int Year { get; set; }
        public string Category { get; set; }
        public List<Nomination> Nominations { get; set; }
        public List<Vote> Votes { get; set; }
        public string JsonVotes { get; set; }
        public string JsonNomineeNames { get; set; }
        public List<Vote> MyVotes { get; set; }
        public List<KeyValuePair<string, string>> AllYearCategoryCombinations { get; set; }
        public string GetVoteByYear(string year)
        {
            Vote vote = MyVotes.Where(v => v.Date.Year.ToString() == year).FirstOrDefault();
            if (vote == null)
            {
                return "";
            }
            else
            {
                return vote.Nomination.Nominee;
            }
        }
    }
}
