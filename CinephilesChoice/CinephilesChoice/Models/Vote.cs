using System;

namespace CinephilesChoice.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int NominationId { get; set; }
        public Nomination Nomination { get; set; }
        public int MoviegoerId { get; set; }
        public Moviegoer Moviegoer { get; set; }
        public DateTime Date { get; set; }
    }
}
