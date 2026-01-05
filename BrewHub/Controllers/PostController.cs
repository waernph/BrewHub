using BrewHub.Core.Interfaces;
using BrewHub.Data.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        private readonly ICommentService _commentService;

        public PostController(IPostService service, ICommentService commentService)
        {
            _service = service;
            _commentService = commentService;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _service.GetAllPosts();
            return Ok(posts);
        }

        [AllowAnonymous]
        [HttpGet("{searchString}")]
        public async Task<IActionResult> SearchPost(string searchString)
        {
            var result = await _service.GetPostBySearch(searchString);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("newPost")]
        public async Task<IActionResult> NewPost(int userId, int categoryId, string postTitle, string postBody)
        {
            await _service.NewPost(postTitle, postBody, userId, categoryId);
            return Ok("New post created successfully!");
        }

        [Authorize]
        [HttpDelete("deletePost")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var result = _service.PostExists(postId);
            if (!await result)
            {
                return NotFound("Post not found.");
            }
            await _commentService.DeleteCommentsByPostId(postId);
            await _service.DeletePost(postId);
            return Ok("Post deleted successfully!");
        }

    }
}
