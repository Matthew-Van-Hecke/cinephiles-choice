using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Nomination")]
        public int NominationId { get; set; }
        public Nomination Nomination { get; set; }
        [ForeignKey("Moviegoer")]
        public int MoviegoerId { get; set; }
        public Moviegoer Moviegoer { get; set; }
        public DateTime Date { get; set; }
    }
}
