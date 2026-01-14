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

        public async Task DeletePost(int postId)
        {
            var postToDelete = _context.Posts.Find(postId)!;
            _context.Posts.Remove(postToDelete);
            _context.SaveChanges();
        }

        public async Task<List<Post>> GetAllPosts()
        {
            var result = _context.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public async Task<List<Post>> GetPostByCategory(int categoryId)
        {
            var result = _context.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .Where(p => p.Category.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();
            return await result;
        }

        public async Task<List<Post>> GetPostBySearch(string searchInput)
        {
            var result = await _context.Posts
                                .Include(p => p.User)
                                .Include(p => p.Category)
                                .Include(p => p.Comments)
                                .ThenInclude(c => c.User)
                                .Where(p => p.PostTitle.ToLower()
                                .Contains(searchInput.ToLower()))
                                .AsNoTracking()
                                .ToListAsync();
            return result;
        }

        public async Task NewPost(string postTitle, string postBody, int userId, int categoryId)
        {
            var user = _context.Users.Find(userId);
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            if (category == null)
            {
                throw new Exception("No such categoy");
            }
            else
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

        public async Task<Post> PostExists(int postId)
        {
            return await _context.Posts.FindAsync(postId);
        }

        public async Task UpdatePost(string? postTitle, string? postBody, int? categoryId, int postId)
        {
            var post = _context.Posts.Find(postId)!;

            var category = _context.Categories.Find(categoryId);

            if (postTitle != null)
            {
                post.PostTitle = postTitle;
            }
            if (postBody != null)
            {
                post.PostBody = postBody;
            }
            if (categoryId != null)
            {
                if (category != null)
                {
                    post.CategoryId = category.CategoryId;
                }
            }
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}
