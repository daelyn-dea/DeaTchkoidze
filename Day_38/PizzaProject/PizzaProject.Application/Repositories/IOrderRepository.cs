using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll(CancellationToken cancellationToken);
        Task<Order> Get(int id, CancellationToken cancellationToken);
        Task<int> Create(Order order, CancellationToken cancellationToken);
        Task CreateBasket(int orderId, int pizzaId, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
