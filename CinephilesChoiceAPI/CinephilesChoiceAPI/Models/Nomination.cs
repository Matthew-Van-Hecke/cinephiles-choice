using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Models
{
    public class Nomination
    {
        [Key]
        public int Id { get; set; }
        public string Nominee { get; set; }
        [ForeignKey("Movie")]
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
        public string AwardCategory { get; set; }
        public bool IsWinner { get; set; }
        public string Year { get; set; }
    }
}
