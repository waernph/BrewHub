using BrewHub.Core.Interfaces;
using BrewHub.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddComment(string inputCommentText, int userId, int postId)
        {
            await _service.NewComment(inputCommentText, userId, postId);
            return Ok("Comment added successfully!");
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateComment(int CommentId, string NewCommentText)
        {
            await _service.UpdateComment(CommentId, NewCommentText);
            return Ok("Comment updated successfully!");
        }
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteComment(int CommentId)
        {
            await _service.DeleteComment(CommentId);
            return Ok("Comment deleted successfully!");
        }

    }
}
