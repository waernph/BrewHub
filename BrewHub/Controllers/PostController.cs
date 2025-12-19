using BrewHub.Core.Interfaces;
using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public IActionResult GetAllPosts()
        {
            return Ok(_service.GetAllPosts());
        }


        [HttpGet("{searchString}")]
        public IActionResult SearchPost(string searchString)
        {
            var result = _service.GetPostBySearch(searchString);
            return Ok(result);
        }

        [HttpPost("newPost")]
        public IActionResult NewPost(int userId, int categoryId, string postTitle, string postBody)
        {
            _service.NewPost(postTitle, postBody, userId, categoryId);
            return Ok("New post created successfully!");
        }

    }
}
