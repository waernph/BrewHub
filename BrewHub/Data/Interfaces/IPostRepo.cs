using BrewHub.Data.Entities;

namespace BrewHub.Data.Interfaces
{
    public interface IPostRepo
    {
        Task DeletePost(int postId);
        Task<List<Post>> GetAllPosts();
        Task<List<Post>> GetPostBySearch(string searchInput);
        Task<List<Post>> GetPostByCategory(int categoryId);
        Task NewPost(string postTitle, string postBody, int userId, int categoryId);
        Task<Post> PostExists(int postId);
        Task UpdatePost(string? postTitle, string? postBody, int? categoryId, int postId);
    }
}
