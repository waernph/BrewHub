using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BrewHub.Data.Repos
{
    public class PostRepo : IPostRepo
    {
        private readonly BrewHubContext _context;

        public PostRepo(BrewHubContext context)
        {
            _context = context;
        }

        public List<Post> GetAllPosts()
        {
            var allPosts = _context.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .AsNoTracking()
                .ToList();
            return allPosts;
        }

        public Post GetPostById(int id)
        {
            Post ? post = _context.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefault(p => p.PostId == id);
            return post;
        }
    }
}
