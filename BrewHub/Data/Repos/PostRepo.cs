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

        public Task<bool> DeletePost(int postId)
        {
            var postToDelete = _context.Posts.Find(postId);
            if (postToDelete != null)
            {
                _context.Posts.Remove(postToDelete);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
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

        public async Task<bool> PostExists(int postId)
        {
            var postExists = await _context.Posts.AnyAsync(p => p.PostId == postId);
            if (postExists)
                return postExists;
            return false;
        }
    }
}
