namespace PizzaProject.Application.Validators
{
    public interface IValidatorService
    {
        Task<bool> ExistsAddressByUserId(int userId, CancellationToken cancellationToken); //address userid
        Task<bool> ExistsAddressByUserIdandId(int id, int userId, CancellationToken cancellationToken); //address uder id & id
        Task<bool> ExistsAddressById(int id, CancellationToken cancellationToken); // address id
        Task<bool> ExistsPizzaById(int id, CancellationToken cancellationToken); //pizza id
        Task<bool> ExistsOrderById(int id, CancellationToken cancellationToken); // order id
        Task<bool> ExistsRankByUserIdAndPizzaId(int userId, int pizzaId, CancellationToken cancellationToken); // rank userid & pizzaId
        Task<bool> ExistsUserById(int id, CancellationToken cancellationToken); // user id
    }
}
