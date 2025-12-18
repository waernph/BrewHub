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
        public void AddNewUser(string username, string password, string email)
        {
            var user = new User
            {
                UserName = username,
                Password = password,
                Email = email
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
