using AutoMapper;

namespace BrewHub.Data.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Data.Entities.Category, Data.DTO.CategoryDTO>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.CategoryName));
        }
    }
}
