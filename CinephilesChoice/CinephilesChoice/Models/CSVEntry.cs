using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Models
{
    public class CSVEntry
    {
        public int Year { get; set; }
        public string Category { get; set; }
        public bool IsWinner { get; set; }
        public string Entity { get; set; }
        public string Film { get; set; }
    }
}
