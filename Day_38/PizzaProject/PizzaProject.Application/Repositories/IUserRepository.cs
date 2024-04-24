using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll(CancellationToken cancellationToken);
        Task<User> Get(int id, CancellationToken cancellationToken);
        Task<int> Create(User user, CancellationToken cancellationToken);
        Task Update(User user, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<bool> ExistsUserById(int id, CancellationToken cancellationToken);
    }
}
