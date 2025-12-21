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
                .Include(p => p.Comments)
                .ToList();
            return allPosts;
        }

        public List<Post> GetPostBySearch(string searchInput)
        {
            var result = _context.Posts.Where(p => p.PostBody.Contains(searchInput) || p.PostTitle.Contains(searchInput))
                        .ToList();

            return result;
        }

        public void NewPost(string postTitle, string postBody, int userId, int categoryId)
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
                _context.Posts.Add(newPost);
                _context.SaveChanges();
            }
        }
    }
}
