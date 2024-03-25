using ToDo.Application.Users.RequestModels;
using ToDo.Application.Users.ResponseModels;

namespace ToDo.Application.Users
{
    public interface IUserService
    {
        Task RegisterAsync(UserRequestPostModel user, CancellationToken cancellationToken);
        Task<UserResponseModel> LoginAsync(UserRequestPostModel user, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
