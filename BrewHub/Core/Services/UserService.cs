using AutoMapper;
using BrewHub.Core.Interfaces;
using BrewHub.Data.DTO;
using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BrewHub.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserService(IUserRepo repo, IMapper mapper, IConfiguration config)
        {
            _repo = repo;
            _mapper = mapper;
            _config = config;
        }

        public async Task AddNewUser(string username, string password, string email)
        {
            await _repo.AddNewUser(username, password, email);
        }
        public async Task UpdateUser(int userId, string oldPassword, string? newUsername, string? newPassword, string? newEmail)
        {
            var user = await _repo.GetUserById(userId);
            if (oldPassword == user.Password)
                await _repo.UpdateUser(userId, newUsername, newPassword, newEmail);
            else
                throw new UnauthorizedAccessException("Old password does not match.");
        }


        public async Task<bool> Login(string username, string password)
        {
            var user = await _repo.Login(username);
            if (user.Password != password)
                return false;
            else
                return true;
        }
        public async Task<string> GenerateToken(string username)
        {
            var user = await _repo.Login(username);
            var userRole = user.Role;
            var userId = user.UserId;
            List <Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, user.Role));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.UserData, user.UserId.ToString()));
            var IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["ApiKey"] !));
            var signinCredentials = new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256);
            

            var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5217",
                    audience: "http://localhost:5217",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signinCredentials);
                

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }

        public async Task DeleteUser(int userId, string password)
        {
            var user = await _repo.GetUserById(userId);
            if (user.Password != password)
                throw new UnauthorizedAccessException("Password does not match.");           
            else
                await _repo.DeleteUser(userId);
        }
    }
}
