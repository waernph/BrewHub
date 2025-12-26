using BrewHub.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await _service.GetAllPosts());
        }


        [HttpGet("{searchString}")]
        public async Task<IActionResult> SearchPost(string searchString)
        {
            var result = await _service.GetPostBySearch(searchString);
            return Ok(result);
        }

        [HttpPost("newPost")]
        public async Task<IActionResult> NewPost(int userId, int categoryId, string postTitle, string postBody)
        {
            await _service.NewPost(postTitle, postBody, userId, categoryId);
            return Ok("New post created successfully!");
        }

    }
}
