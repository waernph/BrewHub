using BrewHub.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _newUserRepo;
        public UserController(IUserRepo UserRepo)
        {
            _newUserRepo = UserRepo;
        }
        [HttpPost("register")]
        public IActionResult RegisterUser(string username, string password, string email)
        {
            _newUserRepo.AddNewUser(username, password, email);
            return Ok("Brewer registered successfully!");
        }
        [HttpPut("update")]
        public IActionResult UpdateUser(string oldUsername, string oldPassword, string newUsername, string newPassword, string newEmail)
        {
            return Ok();
        }
    }
}
