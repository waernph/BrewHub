using BrewHub.Data.Entities;

namespace BrewHub.Data.Interfaces
{
    public interface IPostRepo
    {
        Task DeletePost(int postId);
        Task<List<Post>> GetAllPosts();
        Task<List<Post>> GetPostBySearch(string searchInput);
        Task NewPost(string postTitle, string postBody, int userId, string categoryName);
        Task<Post> PostExists(int postId);
        Task UpdatePost(string? postTitle, string? postBody, string? categoryName, int postId);
    }
}
