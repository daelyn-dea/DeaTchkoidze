using Mapster;
using ToDo.Application.Exceptions;
using ToDo.Application.Subtasks;
using ToDo.Application.ToDos.RequestModel;
using ToDo.Application.ToDos.ResponseModel;
using ToDo.Application.ToDos.ToDoItemRequestModel;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.ToDos;

namespace ToDo.Application.ToDos
{
    public class ToDoService : IToDoService
    {

        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(ToDoItemRequestPostModel todo, CancellationToken cancellationToken)
        {
           await _repository.CreateAsync(todo.Adapt<ToDoItem>(), cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id, int ownerId, CancellationToken cancellationToken)
        {
            if (!await _repository.ExistsByUserIsAndIs(ownerId, id, cancellationToken))
                throw new ToDoItemNotFoundException();

            var bla = await _repository.GetAsyncBeId(id, ownerId, cancellationToken);
           // var blu = bla.Adapt<ToDoItem>();
            var ku = bla.Subtasks;
            if(ku != null)
            foreach(var i in ku)
            {
                    i.IsDeleted = true;
            }
            await _repository.DeleteAsync(id, cancellationToken).ConfigureAwait(false);

        }


        public async Task<List<ToDoItemResponseModel>> GetAllAsyncByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            var result =  await _repository.GetAllAsyncByOwnerId(ownerId, cancellationToken).ConfigureAwait(false);
            return result.Adapt<List<ToDoItemResponseModel>>();
        }

        public async Task<ToDoItemResponseModel> GetAsync(int id,int ownerId, CancellationToken cancellationToken)
        {
            if (!await _repository.ExistsByUserIsAndIs(ownerId, id, cancellationToken))
                throw new ToDoItemNotFoundException();

            var result = await _repository.GetAsyncBeId(id, ownerId, cancellationToken).ConfigureAwait(false);
            return result.Adapt<ToDoItemResponseModel>();

        }

        public async Task<List<ToDoItemResponseModel>> GetAsyncByStatus(Status status, int ownerId, CancellationToken cancellationToken)
        {

            var result = await _repository.GetAsyncByStatus(status, ownerId, cancellationToken).ConfigureAwait(false);
            return result.Adapt<List<ToDoItemResponseModel>>();

        }

        public async Task PatchAsync(ToDoItemRequestPatchModel todo, CancellationToken cancellationToken)
        {
            if (await _repository.ExistsByUserIsAndIs(todo.OwnerId, todo.id, cancellationToken))
            {

                if (todo.TargetCompletionDate != null)
                {
                    await _repository.UpdateAsyncCompletionDate(todo.id, (DateTime)todo.TargetCompletionDate, cancellationToken);
                }
                if (todo.Title != null)
                {
                    await _repository.UpdateAsyncTitle(todo.id, todo.Title, cancellationToken);
                }
            } else
            {
                throw new ToDoItemNotFoundException();
            }
        }

        public async Task UpdateAsyncStatus(int id, int userId, CancellationToken cancellationToken)
        {
            if (!await _repository.ExistsByUserIsAndIs(userId, id, cancellationToken))
                throw new ToDoItemNotFoundException();
            await _repository.UpdateAsyncStatus(id, cancellationToken).ConfigureAwait(false);   
        }

    }
}
