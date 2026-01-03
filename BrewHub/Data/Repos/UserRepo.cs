using AutoMapper;
using BrewHub.Data.DTO;
using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BrewHub.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly BrewHubContext _context;
        public UserRepo(BrewHubContext context)
        {
            _context = context;
        }
        public async Task AddNewUser(string username, string password, string email)
        {
            var user = new User
            {
                UserName = username,
                Password = password,
                Email = email
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            var users = _context.Users.ToListAsync();
            return await users;
        }
        public async Task<User> Login(string username) 
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                throw new SecurityTokenException("Invalid username or password");
            }
            return user;
        }
    }
}
