using BrewHub.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _postRepo;

        public PostController(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }
        [HttpGet("all")]
        public IActionResult GetAllPosts()
        {
            var posts = _postRepo.GetAllPosts();
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = _postRepo.GetPostById(id);
            if (post == null)
            {
                return NotFound("Post not found.");
            }
            return Ok(post);
        }
    }
}
