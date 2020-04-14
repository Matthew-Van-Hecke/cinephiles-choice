using Microsoft.EntityFrameworkCore;

namespace CinephilesChoiceAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<Movie> Movies { get; set; }
    }
}
