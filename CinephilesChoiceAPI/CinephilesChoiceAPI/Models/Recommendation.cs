using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Models
{
    public class Recommendation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [ForeignKey("Moviegoer")]
        public int MoviegoerId { get; set; }
        public Moviegoer Moviegoer { get; set; }
    }
}
