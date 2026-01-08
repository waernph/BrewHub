using BrewHub.Core.Interfaces;
using BrewHub.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BrewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly IJwtGetter _jwt;

        public CommentController(ICommentService service, IJwtGetter jwt)
        {
            _service = service;
            _jwt = jwt;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddComment(string inputCommentText, int postId)
        {
            var userId =  await _jwt.GetLoggedInUserId();
            await _service.NewComment(inputCommentText, userId, postId);
            return Ok("Comment added successfully!");
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateComment(int CommentId, string NewCommentText)
        {
            var userId = await _jwt.GetLoggedInUserId();
            await _service.UpdateComment(CommentId, NewCommentText, userId);
            return Ok("Comment updated successfully!");
        }
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteComment(int CommentId)
        {
            var userId = await _jwt.GetLoggedInUserId();
            await _service.DeleteComment(CommentId, userId);
            return Ok("Comment deleted successfully!");
        }

    }
}
