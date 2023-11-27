using Response;
using Request.Auth;
using Database.Context;
using Repositories.Auth.Abstractions;

using Microsoft.EntityFrameworkCore;
using Mapper.Abstractions;

namespace Repositories.Auth.Implementations;

public sealed class AuthRepository : IAuthRepository
{
    private readonly MyDbContext _context;

    private readonly IUserMapper _mapper;

    public AuthRepository(MyDbContext context, IUserMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserResponse> Login(LoginRequest request)
    {
        var user = await _context.Users.FirstAsync(
            u => u.Email == request.Email && u.Password == request.Password
        );

        return _mapper.ToResponse(user);
    }

    public async Task Register(RegisterRequest request)
    {
        var userMapper = _mapper.ToModel(request);
        await _context.Users.AddAsync(userMapper);
        await _context.SaveChangesAsync();
    }
}
