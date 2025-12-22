using BrewHub.Data.DTO;
using BrewHub.Data.Entities;

namespace BrewHub.Core.Interfaces
{
    public interface IUserService
    {
        public void AddNewUser(string username, string password, string email);
        public List<UserDTO> GetUsers();
    }
}
