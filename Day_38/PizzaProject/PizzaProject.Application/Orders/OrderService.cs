using Mapster;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;
using PizzaProject.Application.Validators;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IValidatorService _validator;

        public OrderService(IOrderRepository repository, IValidatorService validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task Create(OrderRequestModel order, CancellationToken cancellationToken)
        {
            var orderToInsert = order.Adapt<Order>();

            if(! await _validator.ExistsUserById(order.UserId, cancellationToken))
            {
                throw new UserNotFoundException($"{order.UserId}");
            }
            if(! await _validator.ExistsAddressById(order.AddressId, cancellationToken))
            {
                throw new UserNotFoundException($"{order.AddressId}");
            }
            for(int i = 0; i < order.PizzasIds.Count; i++)
            {
                int j = i;
                if (!await _validator.ExistsPizzaById(order.PizzasIds[j], cancellationToken))
                {
                    throw new PizzaNotFoundException($"{order.PizzasIds[j]}");
                }
            }

            var orderId = await _repository.Create(orderToInsert, cancellationToken);
            for(var i = 0; i < order.PizzasIds.Count; i++)
            {
                int j = i;
                await _repository.CreateBasket(orderId, order.PizzasIds[j], cancellationToken);
            }
        }

        public async Task<OrderResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            if (!await _validator.ExistsOrderById(id, cancellationToken))
                throw new OrderNotFoundException(id.ToString());

            var result = await _repository.Get(id, cancellationToken);

            return result.Adapt<OrderResponseModel>();

        }

        public async Task<List<OrderResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll(cancellationToken);

            return result.Adapt<List<OrderResponseModel>>();
        }
    }
}
