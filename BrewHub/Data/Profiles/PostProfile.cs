using AutoMapper;
using BrewHub.Data.DTO;
using BrewHub.Data.Entities;

namespace BrewHub.Data.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(src => src.PostTitle))
                .ForMember(dest => dest.Body,
                    opt => opt.MapFrom(src => src.PostBody))
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => src.PostCreatedDate))
                .ForMember(dest => dest.Comments,
                    opt => opt.MapFrom(src => src.Comments));
        }
    }
}

