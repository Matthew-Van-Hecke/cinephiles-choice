using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Models
{
    public class YearCategoryModel
    {
        public YearCategoryModel(string year, string category)
        {
            Year = year;
            Category = category;
        }
        public string Year { get; }
        public string Category { get; }
    }
}
