using Mapster;
using ToDo.Application.Exceptions;
using ToDo.Application.Subtasks.RequestModel;
using ToDo.Application.Subtasks.ResponseModel;
using ToDo.Domain.Subtasks;

namespace ToDo.Application.Subtasks
{
    public class SubtaskService : ISubtaskService
    {
        private readonly ISubtaskRepository _repository;

        public SubtaskService(ISubtaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SubTaskResponseModel>> GetAllAsyncByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsyncByOwnerId(ownerId, cancellationToken).ConfigureAwait(false);
            return result.Adapt<List<SubTaskResponseModel>>();
        }

        public async Task<SubTaskResponseModel> GetAsyncById(int id, int ownerId, CancellationToken cancellationToken)
        {
            if(!await _repository.ExistsByUserIdAndId(ownerId, id, cancellationToken).ConfigureAwait(false))
            {
                throw new SubTaskNotFoundException();
            }
            var result = await _repository.GetAsyncById(id, cancellationToken).ConfigureAwait(false);
            return result.Adapt<SubTaskResponseModel>();
        }

        public async Task<List<SubTaskResponseModel>> GetAsyncByToDoId(int toDoId, int ownerId, CancellationToken cancellationToken)
        {
            if (!await _repository.ExistsByUserIdAndToDoId(toDoId, ownerId, cancellationToken).ConfigureAwait(false))
            {
                throw new ToDoItemNotFoundException();
            }
            var result = await _repository.GetAsyncByToDoId(toDoId, cancellationToken).ConfigureAwait(false);
            return result.Adapt<List<SubTaskResponseModel>>();
        }

        public async Task CreateAsync(SubtaskRequestPostModel subtask, int ownerId, CancellationToken cancellationToken)
        {
            if (!await _repository.ExistsByUserIdAndId(ownerId, subtask.ToDoItemId, cancellationToken).ConfigureAwait(false))
            {
                throw new ToDoItemNotFoundException();
            }
            var result = subtask.Adapt<Subtask>();
           // result.ToDoItem.OwnerId = ownerId;
            await _repository.CreateAsync(result, cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id, int ownerId, CancellationToken cancellationToken)
        {
            if (!await _repository.ExistsByUserIdAndId(ownerId, id, cancellationToken).ConfigureAwait(false))
            {
                throw new SubTaskNotFoundException();
            }
            await _repository.DeleteAsync(id, cancellationToken).ConfigureAwait(false);
        }
        public async Task UpdateAsyncTitle(int id, string title, int ownerId, CancellationToken cancellationToken)
        {
            if (await _repository.ExistsByUserIdAndId(ownerId, id, cancellationToken).ConfigureAwait(false))
            {
                throw new SubTaskNotFoundException();
            }
            await _repository.UpdateAsyncTitle(id, title, cancellationToken).ConfigureAwait(false);
        }

    }
}
