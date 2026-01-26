namespace BrewHub.Core.Interfaces
{
    public interface IUserService
    {
        Task AddNewUser(string username, string password, string email);

        Task UpdateUser(int userId, string oldPassword, string? newUsername, string? newPassword, string? newEmail);
        Task<bool> Login(string username, string password);
        Task<string> GenerateToken(string username);
        Task DeleteUser(int userId, string password);
    }
}
