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

        public async Task<bool> DeletePost(int postId)
        {
            
            return await _repo.DeletePost(postId);
        }

        public async Task<List<PostDTO>> GetAllPosts()
        {
            var post = await _repo.GetAllPosts();
            return _mapper.Map<List<PostDTO>>(post);
        }

        public async Task<List<Post>> GetPostBySearch(string searchInput)
        {
            return await _repo.GetPostBySearch(searchInput);
        }

        public async Task NewPost(string postTitle, string postBody, int userId, int categoryId)
        {
            await _repo.NewPost(postTitle, postBody, userId, categoryId);
        }

        public async Task<bool> PostExists(int postId)
        {
            return await _repo.PostExists(postId);
        }
    }
}
