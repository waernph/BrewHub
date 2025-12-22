using BrewHub.Data.DTO;
using BrewHub.Data.Entities;

namespace BrewHub.Data.Interfaces
{
    public interface IUserRepo
    {
        public void AddNewUser(string username, string password, string email);
        public List<User> GetUsers();
        
    }
}
