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

        public List<PostDTO> GetAllPosts()
        {
            var post = _repo.GetAllPosts();
            return _mapper.Map<List<PostDTO>>(post);

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
