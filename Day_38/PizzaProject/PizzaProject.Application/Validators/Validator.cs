using PizzaProject.Application.Repositories;

namespace PizzaProject.Application.Validators
{
    public class ValidatorService : IValidatorService
    {

        private readonly IAddressRepository _addressRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IRankHistoryRepository _rankHistoryRepository;
        private readonly IUserRepository _userRepository;
        public ValidatorService(IAddressRepository addressRepository, IOrderRepository orderRepository, IPizzaRepository pizzaRepository, IRankHistoryRepository rankHistoryRepository, IUserRepository userRepository)
        {
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
            _rankHistoryRepository = rankHistoryRepository;
            _userRepository = userRepository;
        }
        public async Task<bool> ExistsAddressById(int id, CancellationToken cancellationToken)
        {
            return await _addressRepository.ExistsAddressById(id, cancellationToken);
        }

        public async Task<bool> ExistsAddressByUserId(int userId, CancellationToken cancellationToken)
        {
            return await _addressRepository.ExistsAddressByUserId(userId, cancellationToken);
        }

        public async Task<bool> ExistsAddressByUserIdandId(int id, int userId, CancellationToken cancellationToken)
        {
            return await _addressRepository.ExistsAddressByUserIdandId(id, userId, cancellationToken);
        }

        public async Task<bool> ExistsOrderById(int id, CancellationToken cancellationToken)
        {
            return await _orderRepository.Exists(id, cancellationToken);
        }

        public async Task<bool> ExistsPizzaById(int id, CancellationToken cancellationToken)
        {
            return await _pizzaRepository.Exists(id, cancellationToken);
        }

        public async Task<bool> ExistsRankByUserIdAndPizzaId(int userId, int pizzaId, CancellationToken cancellationToken)
        {
           return await _rankHistoryRepository.ExistsRankByUserIdAndPizzaId(userId, pizzaId, cancellationToken);
        }

        public async Task<bool> ExistsUserById(int id, CancellationToken cancellationToken)
        {
            return await _userRepository.ExistsUserById(id, cancellationToken);
        }
    }
}
