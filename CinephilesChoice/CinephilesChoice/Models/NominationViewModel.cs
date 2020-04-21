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
    }
}
