using AutoMapper;
using BrewHub.Data.DTO;
using BrewHub.Data.Entities;

namespace BrewHub.Data.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Username,
                    opt => opt.MapFrom(src => src.UserName));
        }
    }
}

