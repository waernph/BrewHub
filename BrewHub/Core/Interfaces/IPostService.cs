using BrewHub.Data.DTO;
using BrewHub.Data.Entities;

namespace BrewHub.Core.Interfaces
{
    public interface IPostService
    {
        Task DeletePost(int postId, int userId);
        Task<List<PostDTO>> GetAllPosts();
        Task<List<PostDTO>> GetPostBySearch(string searchInput);
        Task<List<PostDTO>> GetPostsByCategory(string searchInput);
        Task NewPost(string postTitle, string postBody, int userId, string categoryName);
        Task<Post> PostExists(int postId);
        Task UpdatePost(string? postTitle, string? postBody, string? categoryName, int postId);
    }
}
