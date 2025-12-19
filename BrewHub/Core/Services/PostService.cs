using BrewHub.Core.Interfaces;
using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;

namespace BrewHub.Core.Services
{
    

    public class PostService : IPostService
    {
        private readonly IPostRepo _repo;
        public PostService(IPostRepo repo)
        {
            _repo = repo;
        }

        public List<Post> GetAllPosts()
        {
            return _repo.GetAllPosts();
        }

        public List<Post> GetPostBySearch(string searchInput)
        {
            return _repo.GetPostBySearch(searchInput);
        }

        public void NewPost(string postTitle, string postBody, int userId, int categoryId)
        {
            _repo.NewPost(postTitle, postBody, userId, categoryId);
        }
    }
}
