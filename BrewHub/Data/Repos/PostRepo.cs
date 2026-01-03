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

        public async Task<List<Post>> GetAllPosts()
        {
            var result = _context.Posts.ToListAsync();
            return await result;
        }

        public async Task<List<Post>> GetPostBySearch(string searchInput)
        {
            var result = _context.Posts.Where(p => p.PostBody.Contains(searchInput)
                                                || p.PostTitle.Contains(searchInput))
                                                .ToListAsync();

            return await result;
        }

        public async Task NewPost(string postTitle, string postBody, int userId, int categoryId)
        {
            var user = _context.Users.Find(userId);
            var category = _context.Categories.Find(categoryId);
            {
                Post newPost = new Post
                {
                    User = user,
                    Category = category,
                    PostTitle = postTitle,
                    PostBody = postBody
                };
                await _context.Posts.AddAsync(newPost);
                await _context.SaveChangesAsync();
            }
        }
    }
}
