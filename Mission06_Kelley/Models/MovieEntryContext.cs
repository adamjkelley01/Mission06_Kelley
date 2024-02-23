using Microsoft.EntityFrameworkCore;

namespace Mission06_Kelley.Models
{
    public class MovieEntryContext : DbContext
    {
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base (options)
        {
        }

        public DbSet<Application> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
