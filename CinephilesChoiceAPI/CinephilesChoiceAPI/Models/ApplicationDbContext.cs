using Microsoft.EntityFrameworkCore;

namespace CinephilesChoiceAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Moviegoer> Moviegoers { get; set; }
        public DbSet<Nomination> Nominations { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
