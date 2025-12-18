using Microsoft.EntityFrameworkCore;
using BrewHub.Data.Entities;

namespace BrewHub.Data
{
    public class BrewHubContext : DbContext
    {
        public BrewHubContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
