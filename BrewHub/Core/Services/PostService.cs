using AutoMapper;
using BrewHub.Core.Interfaces;
using BrewHub.Data.DTO;
using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;

namespace BrewHub.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _repo;
        private readonly IMapper _mapper;

        public PostService(IPostRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task DeletePost(int postId, int userId)
        {
            await _repo.DeletePost(postId);
        }

        public async Task<List<PostDTO>> GetAllPosts()
        {
            var post = await _repo.GetAllPosts();
            return _mapper.Map<List<PostDTO>>(post);
        }

        public async Task<List<PostDTO>> GetPostBySearch(string searchInput, List<PostDTO> allPosts)
        {
            string input = searchInput.ToLower();
            var filteredPosts = allPosts.Where(p => p.Title.ToLower().Contains(input)).ToList();
            return filteredPosts;
        }

        public async Task<List<PostDTO>> GetPostsByCategory(string searchInput, List<PostDTO> allPosts)
        {
            var filteredPosts = allPosts.Where(p => p.Category.Name.ToLower().Contains(searchInput.ToLower())).ToList();
            return filteredPosts;
        }

        public async Task NewPost(string postTitle, string postBody, int userId, int categoryId)
        {
            await _repo.NewPost(postTitle, postBody, userId, categoryId);
        }

        public async Task<Post> PostExists(int postId)
        {
            Post post = await _repo.PostExists(postId);

            if (post != null)
            {
                return post;
            }
            else
            {
                throw new Exception("Post does not exist");
            }
        }

        public async Task UpdatePost(string postTitle, string postBody, int categoryId, int postId)
        {
            await _repo.UpdatePost(postTitle, postBody, categoryId, postId);
        }
    }
}
