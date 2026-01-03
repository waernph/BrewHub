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

        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddNewUser(string username, string password, string email)
        {
            await _repo.AddNewUser(username, password, email);
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var user = await _repo.GetUsers();
            return _mapper.Map<List<UserDTO>>(user);

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
            List<Claim> claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mykey1234567&%%485734579453%&//1255362"));
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


    }
}
