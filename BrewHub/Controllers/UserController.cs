using AutoMapper;
using BrewHub.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(string username, string password, string email)
        {
            await _service.AddNewUser(username, password, email);
            return Ok("Brewer registered successfully!");
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(string oldUsername, string oldPassword, string newUsername, string newPassword, string newEmail)
        {
            return Ok("Brewer updated");
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _service.GetUsers());
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var isValid = await _service.Login(username, password);
            if (!isValid)
                return Unauthorized("Invalid username or password");

            return Ok(new { Token = await _service.GenerateToken(username) });
        }
    }
}
