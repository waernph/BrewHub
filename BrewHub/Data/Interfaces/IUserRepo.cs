using BrewHub.Data.DTO;
using BrewHub.Data.Entities;

namespace BrewHub.Data.Interfaces
{
    public interface IUserRepo
    {
        Task AddNewUser(string username, string password, string email);
        Task<List<User>> GetUsers();
        Task<User> Login(string username);
        Task UpdateUser(int userId, string newUsername, string newPassword, string newEmail);
    }
}
