using Database.Context;
using Repositories.User.Abstractions;
using Mapper.Abstractions;
using Microsoft.EntityFrameworkCore;
using Request.User;
using Response;

namespace Repositories.User.Implementations;

public sealed class UserRepository : IUserRepository
{
    private readonly IUserMapper _mapper;

    private readonly MyDbContext _context;

    public UserRepository(IUserMapper mapper, MyDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<UserResponse> GetUserByIdAsync(int id)
    {
        var user = await _context.Users
            .AsNoTracking()
            .Include(u => u.Playlists)
            .FirstAsync(p => p.Id == id);
        var userResponse = _mapper.ToResponse(user);
        return userResponse;
    }

    public async Task<UserResponse> UpdateUserByIdAsync(UpdateUserRequest request)
    {
        var user = await _context.Users
            .AsNoTracking()
            .Include(u => u.Playlists)
            .FirstAsync(p => p.Id == request.Id);
        user = _mapper.ToModel(user, request);
        var userResponse = _mapper.ToResponse(user);
        await _context.SaveChangesAsync();
        return userResponse;
    }
}
