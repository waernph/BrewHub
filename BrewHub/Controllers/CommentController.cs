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
        public IActionResult AddComment(string inputCommentText, int userId, int postId)
        {
            _repo.NewComment(inputCommentText, userId, postId);
            return Ok("Comment added successfully!");
        }

        [HttpPut("update")]
        public IActionResult UpdateComment(int CommentId, string NewCommentText)
        {
            _repo.UpdateComment(CommentId, NewCommentText);
            return Ok("Comment updated successfully!");
        }
        [HttpDelete("delete")]
        public IActionResult DeleteComment(int CommentId)
        {
            _repo.DeleteComment(CommentId);
            return Ok("Comment deleted successfully!");
        }
        [HttpGet("bypost")]
        public IActionResult GetComments(int PostId)
        {
            var comments = _repo.GetComments(PostId);
            return Ok(comments);
        }
    }
}
