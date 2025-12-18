using BrewHub.Data.Entities;

namespace BrewHub.Data.Interfaces
{
    public interface IPostRepo
    {
        public List<Post> GetAllPosts();
        public Post GetPostById(int id);
    }
}
