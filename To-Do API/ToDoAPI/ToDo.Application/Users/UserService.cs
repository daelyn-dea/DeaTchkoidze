using BC = BCrypt.Net.BCrypt;
using Mapster;
using ToDo.Application.Exceptions;
using ToDo.Application.Users.RequestModels;
using ToDo.Application.Users.ResponseModels;
using ToDo.Domain.Users;

namespace ToDo.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseModel> LoginAsync(UserRequestPostModel user, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByUsername(user.Username, cancellationToken);

            if (result == null)
                throw new UserNotFoundException();

            var verifyPassword = BC.EnhancedVerify(user.Password, result.PasswordHash);

            if (!verifyPassword)
                throw new IncorrectPasswordException();

            return result.Adapt<UserResponseModel>();
        }

        public async Task RegisterAsync( UserRequestPostModel user, CancellationToken cancellationToken)
        {
            user.Password = BC.EnhancedHashPassword(user.Password, 13);

            var userEntity = user.Adapt<User>();

            await _repository.CreateAsync(userEntity, cancellationToken);
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            return await _repository.Exists(id, cancellationToken); 
        }
    }
}