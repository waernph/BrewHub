using BrewHub.Data.Entities;

namespace BrewHub.Data.Interfaces
{
    public interface IUserRepo
    {
        Task AddNewUser(string username, string password, string email);
        Task DeleteUser(int userId);
        Task<User> GetUserById(int userId);
        Task<User> Login(string username);
        Task UpdateUser(int userId, string? newUsername, string? newPassword, string? newEmail);
    }
}
