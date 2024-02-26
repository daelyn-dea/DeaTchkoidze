namespace PizzaProject.Application.Addresses
{
    public interface IAddressService
    {
        Task<AddressResponseModel> Get(int id, CancellationToken cancellationToken);
        Task<List<AddressResponseModel>> GetAllByUserId(int id, CancellationToken cancellationToken);
        Task Create(AddressRequestModel pizza, int userId, CancellationToken cancellationToken);
        Task Update(int id, AddressRequestModel pizza, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task DeleteByUserId(int userId, CancellationToken cancellationToken);
    }
}
