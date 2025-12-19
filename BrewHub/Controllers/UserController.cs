using AutoMapper;
using BrewHub.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(string username, string password, string email)
        {
            _service.AddNewUser(username, password, email);
            return Ok("Brewer registered successfully!");
        }
        [HttpPut("update")]
        public IActionResult UpdateUser(string oldUsername, string oldPassword, string newUsername, string newPassword, string newEmail)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_service.GetUsers());
        }
    }
}
