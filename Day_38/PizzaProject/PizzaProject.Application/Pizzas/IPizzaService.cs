namespace PizzaProject.Application.Pizzas
{
    public interface IPizzaService
    {
        Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<PizzaResponseModel> Get(int id, CancellationToken cancellationToken);
        Task Create(PizzaRequestModel pizza, CancellationToken cancellationToken);
        Task Update(int id, PizzaRequestModel pizza, CancellationToken cancellationToken);
        Task UpdatePrice(int id, decimal price, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
