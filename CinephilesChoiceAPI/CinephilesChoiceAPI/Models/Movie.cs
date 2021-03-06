using System;
using System.ComponentModel.DataAnnotations;

namespace CinephilesChoiceAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public string Poster { get; set; }
    }
}
