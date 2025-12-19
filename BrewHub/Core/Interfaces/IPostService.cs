using BrewHub.Data.Entities;

namespace BrewHub.Core.Interfaces
{
    public interface IPostService
    {
        public List<Post> GetAllPosts();
        public List<Post> GetPostBySearch(string searchInput);
        public void NewPost(string postTitle, string postBody, int userId, int categoryId);
    }
}
