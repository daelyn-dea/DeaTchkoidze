using ToDo.Application.ToDos.RequestModel;
using ToDo.Application.ToDos.ResponseModel;
using ToDo.Application.ToDos.ToDoItemRequestModel;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.ToDos;

namespace ToDo.Application.ToDos
{
    public interface IToDoService
    {
        Task<List<ToDoItemResponseModel>> GetAllAsyncByOwnerId(int ownerId, CancellationToken cancellationToken);
        Task<ToDoItemResponseModel> GetAsync(int id, int ownerId, CancellationToken cancellationToken);
        Task<List<ToDoItemResponseModel>> GetAsyncByStatus(Status status, int ownerId, CancellationToken cancellationToken);
        Task CreateAsync(ToDoItemRequestPostModel todo, CancellationToken cancellationToken);
        Task UpdateAsyncStatus(int id, int ownerId, CancellationToken cancellationToken);
        Task PatchAsync(ToDoItemRequestPatchModel todo, CancellationToken cancellationToken);
        Task DeleteAsync(int id, int ownerId, CancellationToken cancellationToken);
    }
}
