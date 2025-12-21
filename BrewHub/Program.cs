using BrewHub.Core.Interfaces;
using BrewHub.Core.Services;
using BrewHub.Data.Interfaces;
using BrewHub.Data.Profiles;
using BrewHub.Data.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<UserProfile>();
}, typeof(UserProfile));
builder.Services.AddControllers();
    
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BrewHub.Data.BrewHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPostRepo, PostRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
