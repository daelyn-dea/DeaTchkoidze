namespace PizzaProject.Application.Users
{
    public interface IUserService
    {
        Task<List<UserResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<UserResponseModel> Get(int id, CancellationToken cancellationToken);
        Task Create(UserRequestModel user, CancellationToken cancellationToken);
        Task Update(int id, UserRequestModel user, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
