using Database.Context;
using Mapper.Implementations;
using DataSource.Playlist.Implementations;
using Microsoft.EntityFrameworkCore;

using Mapper.Abstractions;
using Repositories.Auth.Abstractions;
using Repositories.Auth.Implementations;
using Repositories.User.Implementations;
using Repositories.User.Abstractions;
using Repositories.Playlist.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(
    config => config.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
);

builder.Services.AddSingleton<IUserMapper, UserMapper>();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
