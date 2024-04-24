using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Subtasks;
using ToDo.Domain.ToDos;

namespace ToDo.Application.Subtasks
{
    public interface ISubtaskRepository
    {
        Task<List<Subtask>> GetAllAsyncByOwnerId(int ownerId, CancellationToken cancellationToken);
        Task<List<Subtask>> GetAsyncByToDoId(int toDoId, CancellationToken cancellationToken);
        Task<Subtask> GetAsyncById(int id, CancellationToken cancellationToken);
        Task<bool> ExistsByUserIdAndId(int userId, int id, CancellationToken cancellationToken);
        Task<bool> ExistsByUserIdAndToDoId(int userId, int toDoId, CancellationToken cancellationToken);
        Task CreateAsync(Subtask subtask, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsyncTitle(int id, string title, CancellationToken cancellationToken);
    }
}
