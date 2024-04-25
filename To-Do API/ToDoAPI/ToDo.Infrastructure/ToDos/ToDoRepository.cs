 using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using ToDo.Application.Exceptions;
using ToDo.Application.Subtasks;
using ToDo.Application.ToDos;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.Subtasks;
using ToDo.Domain.ToDos;
using ToDo.Domain.Users;
using ToDo.Persistence.Context;

namespace ToDo.Infrastructure.ToDos
{

    public class ToDoRepository : BaseRepository<ToDoItem>, IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<List<ToDoItem>> GetAllAsyncByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            return  await base.GetManyAsync(item => item.OwnerId == ownerId, cancellationToken).ConfigureAwait(false); 
        }
        public  async Task<ToDoItem> GetAsyncBeId(int id, int userId, CancellationToken cancellationToken)
        {
            return  await GetAsync(id, cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<ToDoItem>> GetAsyncByStatus(Status status, int userId, CancellationToken cancellationToken)
        {
			 throw new Exception();
		}

        public async Task<ToDoItem> GetAsync( int id, CancellationToken cancellationToken)
        {
            return await _dbSet.Include(x => x.Subtasks).FirstAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
        }
        public async Task UpdateAsyncStatus(int id, CancellationToken cancellationToken)
        {
            var toDoItem = await GetAsync(cancellationToken, id);
            if (toDoItem != null)
            {
                if(toDoItem.Status == Status.Done)
                {
                    throw new ToDoItemNotFoundException();
                }
                    toDoItem.Status = Status.Done;
                    await base.UpdateAsync(toDoItem, cancellationToken).ConfigureAwait(false);
                  //  await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                throw new ToDoItemNotFoundException();
            }
        }

        public async Task UpdateAsyncTitle(int id, string title, CancellationToken cancellationToken)
        {
            var toDoItem = await GetAsync(cancellationToken, id).ConfigureAwait(false);
            if (toDoItem != null)
            {
                if (toDoItem.Status == Status.Done)
                {
                    throw new ToDoItemNotFoundException();
                }
                toDoItem.Title = title;
                await  base.UpdateAsync(toDoItem, cancellationToken).ConfigureAwait(false);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                throw new ToDoItemNotFoundException();
            }
        }

        public async Task UpdateAsyncCompletionDate(int id, DateTime date, CancellationToken cancellationToken)
        {
            var toDoItem = await GetAsync(cancellationToken, id).ConfigureAwait(false);
            if (toDoItem != null)
            {
                if (toDoItem.Status == Status.Done)
                {
                    throw new ToDoItemNotFoundException();
                }
                toDoItem.TargetCompletionDate = date;
                await base.UpdateAsync(toDoItem, cancellationToken).ConfigureAwait(false);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                throw new ToDoItemNotFoundException();
            }
        }

        public new async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await GetAsync(id, cancellationToken).ConfigureAwait(false);
           // if (entity is null)
            //{
              //  throw new ToDoItemNotFoundException();
            //}
            //entity.IsDeleted = true;
            //entity.Status = Status.Deleted;
            //entity.Subtasks?.ToList().ForEach(entity => entity.IsDeleted = true);
            //_context.Entry(entity).State = EntityState.Detached;
            //_context.Entry(entity).Property(nameof(entity.Status)).IsModified = true;


            //base._context.CurrentCrudMethod = "Deleted";
            _dbSet.Update(entity);

          //  await base.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> ExistsByUserIsAndIs(int userId, int id, CancellationToken cancellationToken)
        {
            return await base.AnyAsync(x => x.Id == id & x.OwnerId == userId, cancellationToken).ConfigureAwait(false);
        }
    }
}
