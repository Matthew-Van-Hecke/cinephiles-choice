using System.Collections.Generic;

namespace CinephilesChoice.Models
{
    public class VoteViewModel
    {
        public List<Nomination> Nominations { get; set; }
        public Vote Vote { get; set; }
    }
}
