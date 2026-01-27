using BrewHub.Data.Profiles;

namespace BrewHub.Extensions
{
    public static class AutoMapperCollection
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(CategoryProfile));
            services.AddAutoMapper(cfg => { }, typeof(CommentProfile));
            services.AddAutoMapper(cfg => { }, typeof(PostProfile));
            services.AddAutoMapper(cfg => { }, typeof(UserProfile));

            return services;
        }
    }
}
