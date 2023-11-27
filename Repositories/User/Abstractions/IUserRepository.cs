using Request.User;
using Response;

namespace Repositories.User.Abstractions;

public interface IUserRepository
{
    Task<UserResponse> GetUserByIdAsync(int id);

    Task<UserResponse> UpdateUserByIdAsync(UpdateUserRequest request);
}
