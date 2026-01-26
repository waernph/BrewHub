using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;
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
            if (_context.Users.Any(u => u.UserName == username))
            {
                throw new Exception("Username already exists.");
            }
            else
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
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var adminCount = _context.Users.Count(u => u.Role == "Admin");
            if (user.Role == "Admin" && adminCount > 1)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
                throw new InvalidOperationException("There need to be at least one admin.");         
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId)!;
            return user;
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

        public async Task UpdateUser(int userId, string? newUsername, string? newPassword, string? newEmail)
        {
            var user = await _context.Users.FindAsync(userId);
            if (newUsername != null)
                user.UserName = newUsername;

            if (newEmail != null)
                user.Email = newEmail;

            if (newPassword != null)
                user.Password = newPassword;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
