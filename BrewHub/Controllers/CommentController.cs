using BrewHub.Core.Interfaces;
using BrewHub.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _repo;

        public CommentController(ICommentService repo)
        {
            _repo = repo;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddComment(string inputCommentText, int userId, int postId)
        {
            await _repo.NewComment(inputCommentText, userId, postId);
            return Ok("Comment added successfully!");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateComment(int CommentId, string NewCommentText)
        {
            await _repo.UpdateComment(CommentId, NewCommentText);
            return Ok("Comment updated successfully!");
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteComment(int CommentId)
        {
            await _repo.DeleteComment(CommentId);
            return Ok("Comment deleted successfully!");
        }
        [HttpGet("bypost")]
        public async Task<IActionResult> GetComments(int PostId)
        {
            return Ok(await _repo.GetComments(PostId));
        }
    }
}
