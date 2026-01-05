using BrewHub.Core.Interfaces;
using BrewHub.Core.Services;
using BrewHub.Data.Interfaces;
using BrewHub.Data.Profiles;
using BrewHub.Data.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var apiKey = builder.Configuration["ApiKey"];  //Secret key för JWT
//automapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<UserProfile>();
}, typeof(UserProfile));

//JWT
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:5217",
            ValidAudience = "http://localhost:5217",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(apiKey))
        };
    });
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
//JWT-----------------
app.UseAuthentication();

//--------------------
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
