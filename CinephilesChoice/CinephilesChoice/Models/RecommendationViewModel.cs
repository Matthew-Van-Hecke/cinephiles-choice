﻿namespace CinephilesChoice.Models
{
    public class RecommendationViewModel
    {
        public string Year { get; set; }
        public string Category { get; set; }
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
