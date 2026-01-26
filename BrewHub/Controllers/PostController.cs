using BrewHub.Core.Interfaces;

namespace BrewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        private readonly ICommentService _commentService;
        private readonly IJwtGetter _jwtGetter;

        public PostController(IPostService service, ICommentService commentService, IJwtGetter jwtGetter)
        {
            _service = service;
            _commentService = commentService;
            _jwtGetter = jwtGetter;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _service.GetAllPosts();
            return Ok(posts);
        }

        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> SearchPost(string searchInput)
        {
            var filterdPosts = await _service.GetPostBySearch(searchInput);
            if (filterdPosts.Count == 0)
            {
                return NoContent();
            }
            return Ok(await _service.GetPostBySearch(searchInput));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryName">Råvaror/Utrustning/Bryggteknik/Övrigt/Recept</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("byCategory")]
        public async Task<IActionResult> GetPostsByCategory(int categoryId)
        {
            if (categoryId < 1 || categoryId > 5) 
            {
                return BadRequest("Choose between 1 -5");
            }

            try
            {
                return Ok(await _service.GetPostsByCategory(categoryId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [Authorize]
        [HttpPost("newPost")]
        public async Task<IActionResult> NewPost(int categoryId, string postTitle, string postBody)
        {
            try
            {
                var userId = await _jwtGetter.GetLoggedInUserId();
                await _service.NewPost(postTitle, postBody, userId, categoryId);
                return Ok("New post created successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("deletePost")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var userId = await _jwtGetter.GetLoggedInUserId();
            var post = await _service.PostExists(postId);
            if (post is null)
                return NotFound();

            if (post.UserId != userId)
                return Forbid();

            await _commentService.DeleteCommentsByPostId(postId);
            await _service.DeletePost(postId, userId);
            return Ok("Post deleted successfully!");
        }

        [Authorize]
        [HttpPut("updatePost")]
        public async Task<IActionResult> UpdatePost(int postId, string? postTitle, string? postBody, int? categoryId)
        {
            var userId = await _jwtGetter.GetLoggedInUserId();
            var post = await _service.PostExists(postId);
            if (post.UserId == userId && post != null)
            {
                await _service.UpdatePost(postTitle, postBody, categoryId, postId);
                return Ok("Post edited successfully!");
            }

            if (post is null)
                return NotFound();

            if (post.UserId != userId)
                return Forbid();

            return BadRequest();
        }

    }
}
