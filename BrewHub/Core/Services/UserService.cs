using AutoMapper;
using BrewHub.Core.Interfaces;
using BrewHub.Data.DTO;
using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;

namespace BrewHub.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;

        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }

        public void AddNewUser(string username, string password, string email)
        {
            _repo.AddNewUser(username, password, email);
        }

        public List<User> GetUsers()
        {
            return _repo.GetUsers();
        }


    }
}
