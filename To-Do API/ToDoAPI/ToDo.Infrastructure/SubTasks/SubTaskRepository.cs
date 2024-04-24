using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Exceptions;
using ToDo.Application.Subtasks;
using ToDo.Application.ToDos;
using ToDo.Domain.Subtasks;
using ToDo.Domain.ToDos;
using ToDo.Domain.Users;
using ToDo.Persistence.Context;

namespace ToDo.Infrastructure.SubTasks
{
    public class SubTaskRepository : BaseRepository<Subtask>, ISubtaskRepository
    {
        public SubTaskRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<List<Subtask>> GetAllAsyncByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            return await base.GetManyAsync(x => x.ToDoItem.OwnerId == ownerId, cancellationToken).ConfigureAwait(false);
        }
        public async Task<List<Subtask>> GetAsyncByToDoId(int toDoId, CancellationToken cancellationToken)
        {
            return await base.GetManyAsync(x => x.ToDoItemId == toDoId, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Subtask> GetAsyncById(int id, CancellationToken cancellationToken)
        {
            return await base.GetAsync(cancellationToken, id).ConfigureAwait(false);
        }

        public async Task<bool> ExistsByUserIdAndId(int userId, int id, CancellationToken cancellationToken)
        {
            return await base.AnyAsync(x => x.Id == id && x.ToDoItem.OwnerId == userId, cancellationToken).ConfigureAwait(false);
        }
        public async Task<bool> ExistsByUserIdAndToDoId(int userId, int toDoId, CancellationToken cancellationToken)
        {
            var toDoDbSet = _context.Set<ToDoItem>();
            return await toDoDbSet.AnyAsync(x => x.Id == toDoId && x.OwnerId == userId, cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsyncTitle(int id, string title, CancellationToken cancellationToken)
        {
            var subtask = await base.GetAsync(cancellationToken, id).ConfigureAwait(false);
            if (subtask != null)
            {

                subtask.Title = title;
                await base.UpdateAsync(subtask, cancellationToken).ConfigureAwait(false);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                throw new SubTaskNotFoundException();
            }
        }

        public async Task DeleteAllAsync(int toDoId, CancellationToken cancellationToken)
        {
            var entitiesToUpdate = await GetAsyncByToDoId(toDoId, cancellationToken).ConfigureAwait(false);
            entitiesToUpdate.ForEach(entity => entity.IsDeleted = true);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
