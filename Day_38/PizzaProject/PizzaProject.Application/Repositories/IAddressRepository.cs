using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> Get(int id, CancellationToken cancellationToken);
        Task<List<Address>> GetByUserId(int userId, CancellationToken cancellationToken);
        Task Create(Address address, CancellationToken cancellationToken);
        Task Update(Address address, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task DeleteByUserId(int userId, CancellationToken cancellationToken);
        Task<bool> ExistsAddressByUserId(int userId, CancellationToken cancellationToken); 
        Task<bool> ExistsAddressByUserIdandId(int id, int userId, CancellationToken cancellationToken); 
        Task<bool> ExistsAddressById(int id, CancellationToken cancellationToken); 
    }
}
