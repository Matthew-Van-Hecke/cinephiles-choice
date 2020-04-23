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
