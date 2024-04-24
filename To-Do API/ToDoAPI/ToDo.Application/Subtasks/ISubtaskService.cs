using ToDo.Application.Subtasks.RequestModel;
using ToDo.Application.Subtasks.ResponseModel;

namespace ToDo.Application.Subtasks
{
    public interface ISubtaskService
    {
        Task<List<SubTaskResponseModel>> GetAllAsyncByOwnerId(int ownerId, CancellationToken cancellationToken);
        Task<List<SubTaskResponseModel>> GetAsyncByToDoId(int toDoId, int ownerId, CancellationToken cancellationToken);
        Task<SubTaskResponseModel> GetAsyncById(int id, int ownerId, CancellationToken cancellationToken);
        Task CreateAsync(SubtaskRequestPostModel subtask, int ownerId, CancellationToken cancellationToken);
        Task DeleteAsync(int id, int ownerId, CancellationToken cancellationToken);
        Task UpdateAsyncTitle(int id, string title, int ownerId, CancellationToken cancellationToken);
    }
}
