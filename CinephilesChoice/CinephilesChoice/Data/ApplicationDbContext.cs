using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinephilesChoice.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1647fe79-52b5-4ada-9b33-eee4212ddb24",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "72dc7c0b-1dda-48cf-9286-986da0fbe213"
                },
                new IdentityRole
                {
                    Id = "d42d6387-d9ff-40ab-963b-f1dac4a815c1",
                    Name = "Cinephile",
                    NormalizedName = "CINEPHILE",
                    ConcurrencyStamp = "12a7233f-3832-4c9a-ad0f-e6c2b914aceb"
                }
            );
        }
        public DbSet<CinephilesChoice.Models.Nomination> Nomination { get; set; }
        public DbSet<CinephilesChoice.Models.Moviegoer> Moviegoer { get; set; }
        public DbSet<CinephilesChoice.Models.Vote> Vote { get; set; }
        public DbSet<CinephilesChoice.Models.Movie> Movie { get; set; }
    }
}
