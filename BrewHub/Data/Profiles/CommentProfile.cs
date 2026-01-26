using BrewHub.Data.Entities;

namespace BrewHub.Data.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.Comments,
                    opt => opt.MapFrom(src => src.CommentText))
                .ForMember(dest => dest.User,
                    opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => src.CommentCreatedDate));
        }
    }
}
