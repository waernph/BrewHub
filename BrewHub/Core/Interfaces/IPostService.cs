using BrewHub.Data.DTO;
using BrewHub.Data.Entities;

namespace BrewHub.Core.Interfaces
{
    public interface IPostService
    {
        Task<List<PostDTO>> GetAllPosts();
        Task<List<Post>> GetPostBySearch(string searchInput);
        Task NewPost(string postTitle, string postBody, int userId, int categoryId);
    }
}
