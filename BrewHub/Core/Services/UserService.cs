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
        private readonly IMapper _mapper;

        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void AddNewUser(string username, string password, string email)
        {
            _repo.AddNewUser(username, password, email);
        }

        public List<UserDTO> GetUsers()
        {
            var user = _repo.GetUsers();
            return _mapper.Map<List<UserDTO>>(user);

        }


    }
}
