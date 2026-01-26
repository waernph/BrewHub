using BrewHub.Core.Interfaces;
using BrewHub.Core.Services;
using BrewHub.Data.Interfaces;
using BrewHub.Data.Repos;

namespace BrewHub.Extensions
{
    public static class AddScopedCollection
    {
        public static IServiceCollection AddScoped(this IServiceCollection services)
        {
            services.AddScoped<IPostRepo, PostRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ICommentRepo, CommentRepo>();
            
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IJwtGetter, JwtGetter>();
            return services;
        }
            

    }
}
