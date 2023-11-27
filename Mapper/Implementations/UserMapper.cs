using Models;
using Response;
using Request.Auth;

using Riok.Mapperly.Abstractions;
using Request.User;
using Mapper.Abstractions;

namespace Mapper.Implementations;

[Mapper]
public partial class UserMapper : IUserMapper
{
    public partial UserModel ToModel(RegisterRequest request);

    public UserModel ToModel(UserModel model, UpdateUserRequest request)
    {
        model.FirstName = request.FirstName;
        model.Email = request.Email;
        model.Password = request.Password;
        return model;
    }

    public UserResponse ToResponse(UserModel model)
    {
        var userResponse = new UserResponse
        {
            Id = model.Id,
            FirstName = model.FirstName,
            Email = model.Email,
            Terms = model.Terms,
            RegisterDate = model.RegisterDate,
            Playlists = model?.Playlists?.Select(p => p.PlaylistNum).ToList()
        };

        return userResponse;
    }
}
