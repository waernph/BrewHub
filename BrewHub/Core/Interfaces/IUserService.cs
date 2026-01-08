using BrewHub.Data.DTO;
using BrewHub.Data.Entities;

namespace BrewHub.Core.Interfaces
{
    public interface IUserService
    {
        Task AddNewUser(string username, string password, string email);
        Task<List<UserDTO>> GetUsers();
        Task UpdateUser(int userId, string oldPassword, string newUsername, string newPassword, string newEmail);
        Task<bool> Login(string username, string password);
        Task<string> GenerateToken(string username);
    }
}
