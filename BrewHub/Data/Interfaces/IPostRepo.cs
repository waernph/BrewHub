using BrewHub.Data.Entities;

namespace BrewHub.Data.Interfaces
{
    public interface IPostRepo
    {
        Task<List<Post>> GetAllPosts();
        Task<List<Post>> GetPostBySearch(string searchInput);
        Task NewPost(string postTitle, string postBody, int userId, int categoryId);
    }
}
