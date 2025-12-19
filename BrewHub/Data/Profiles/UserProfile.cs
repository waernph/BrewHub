using AutoMapper;
using BrewHub.Data.DTO;
using BrewHub.Data.Entities;
using System;
namespace BrewHub.Data.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Username,
                    opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email));
        }
    }
}

