using Response;
using Request.Auth;

namespace Repositories.Auth.Abstractions;

public interface IAuthRepository
{
    Task<UserResponse> Login(LoginRequest request);

    Task Register(RegisterRequest request);
}
