using ToDo.Domain.Users;

namespace ToDo.Application.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<User> GetAsync(int id, CancellationToken cancellationToken );
        Task<User> GetByUsername(string username, CancellationToken cancellationToken);
        Task CreateAsync(User user, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
