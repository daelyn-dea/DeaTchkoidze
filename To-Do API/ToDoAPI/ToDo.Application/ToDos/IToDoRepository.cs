using ToDo.Domain.ToDos;

namespace ToDo.Application.ToDos
{
    public interface IToDoRepository
    {
            Task<List<ToDoItem>> GetAllAsyncByOwnerId(int ownerId, CancellationToken cancellationToken);
            Task<ToDoItem> GetAsyncBeId(int id, int userId, CancellationToken cancellationToken);
            Task<List<ToDoItem>> GetAsyncByStatus(Status status, int userId, CancellationToken cancellationToken);
            Task<bool> ExistsByUserIsAndIs(int userId, int id, CancellationToken cancellationToken);
            Task CreateAsync(ToDoItem todo, CancellationToken cancellationToken);
            Task UpdateAsyncStatus(int id, CancellationToken cancellationToken);
            Task UpdateAsyncCompletionDate(int id, DateTime date, CancellationToken cancellationToken);
            Task UpdateAsyncTitle(int id, string title, CancellationToken cancellationToken);
            Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
