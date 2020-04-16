using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Models
{
    public class Nomination
    {
        public int Id { get; set; }
        public string Nominee { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string AwardCategory { get; set; }
        public bool IsWinner { get; set; }
        public string Year { get; set; }
    }
}
