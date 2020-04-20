using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Models
{
    public class VoteViewModel
    {
        public List<Nomination> Nominations { get; set; }
        public Vote Vote { get; set; }
    }
}
