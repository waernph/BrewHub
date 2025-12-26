using BrewHub.Data.DTO;
using BrewHub.Data.Entities;

namespace BrewHub.Core.Interfaces
{
    public interface IUserService
    {
        Task AddNewUser(string username, string password, string email);
        Task<List<UserDTO>> GetUsers();
    }
}
