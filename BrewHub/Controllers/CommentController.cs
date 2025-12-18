using BrewHub.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepo _commentRepo;

        public CommentController(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }
        [HttpPost("add")]
        public IActionResult AddComment(int PostId, int UserId, string inputCommentText)
        {
            _commentRepo.AddComment(PostId, UserId, inputCommentText);
            return Ok("Comment added successfully!");
        }
        [HttpPut("update")]
        public IActionResult UpdateComment(int CommentId, string NewCommentText)
        {
            _commentRepo.UpdateComment(CommentId, NewCommentText);
            return Ok("Comment updated successfully!");
        }
        [HttpDelete("delete")]
        public IActionResult DeleteComment(int CommentId)
        {
            _commentRepo.DeleteComment(CommentId);
            return Ok("Comment deleted successfully!");
        }
        [HttpGet("bypost")]
        public IActionResult GetComments(int PostId)
        {
            var comments = _commentRepo.GetComments(PostId);
            return Ok(comments);
        }
    }
}
