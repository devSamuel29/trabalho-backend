using Models;
using Response;
using Request.Auth;
using Request.User;

namespace Mapper.Abstractions;

public interface IUserMapper
{
    UserModel ToModel(RegisterRequest request);

    UserModel ToModel(UserModel model, UpdateUserRequest request);

    UserResponse ToResponse(UserModel model);
}
