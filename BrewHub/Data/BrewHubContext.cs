using Microsoft.EntityFrameworkCore;

namespace BrewHub.Data
{
    public class BrewHubContext : DbContext
    {
        public BrewHubContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Post> Posts { get; set; }
        public DbSet<Entities.Category> Categories { get; set; }
        public DbSet<Entities.Comment> Comments { get; set; }
    }
}
