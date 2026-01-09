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
        private readonly IJwtGetter _jwt;

        public UserController(IUserService service, IJwtGetter JwtGetter)
        {
            _service = service;
            _jwt = JwtGetter;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(string username, string password, string email)
        {
            try
            {
                await _service.AddNewUser(username, password, email);
                return Ok("Brewer registered successfully!");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(string oldPassword, string ? newUsername, string ? newPassword, string ? newEmail)
        {
            var userId = await _jwt.GetLoggedInUserId();
            try 
            {
                await _service.UpdateUser(userId, oldPassword, newUsername, newPassword, newEmail);
                return Ok("Brewer updated");
            }
            catch (UnauthorizedAccessException ex)
            {
                return StatusCode(403, ex.Message);
            }

        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser(string password)
        {
            var userId = await _jwt.GetLoggedInUserId();
            try
            {
                await _service.DeleteUser(userId, password);
                return Ok("Brewer deleted successfully");
            }
            catch (InvalidOperationException ex) //För få admins
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex) //fel lösenord
            {
                return StatusCode(403, ex.Message);
            }
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
