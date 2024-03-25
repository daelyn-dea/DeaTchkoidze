using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static ToDo.API.Infrastructure.Models.StatusEnumModel.StatusEnums;
using System.Security.Claims;
using ToDo.API.Infrastructure.Authentication;
using ToDo.API.Infrastructure.Models.ToDoItemModels;
using ToDo.Application.ToDos.RequestModel;
using ToDo.Application.ToDos.ResponseModel;
using ToDo.Application.ToDos.ToDoItemRequestModel;
using ToDo.Application.ToDos;
using ToDo.Domain.ToDos;
using ToDo.Application.Subtasks;
using Microsoft.AspNetCore.Authorization;
using ToDo.Application.Subtasks.ResponseModel;
using ToDo.Application.Subtasks.RequestModel;
using ToDo.API.Infrastructure.Models.SubTaskModels;
using Mapster;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubtaskController : ControllerBase
    {
        private readonly ISubtaskService _Service;
        private readonly IOptions<AuthenticationConfiguration> _authOptions;
        public SubtaskController(ISubtaskService toDoService, IOptions<AuthenticationConfiguration> authOptions)
        {
            _Service = toDoService;
            _authOptions = authOptions;
        }

        /// <summary>
        /// Retrieves all subtasks.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A list of subtasks.</returns>
        [HttpGet]
        public async Task<List<SubTaskResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            return await _Service.GetAllAsyncByOwnerId(userId, cancellationToken);
        }

        /// <summary>
        /// Retrieves a subtask by its ID.
        /// </summary>
        /// <param name="id">The ID of the subtask.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The subtask.</returns>
        [HttpGet("id/{id}")]
        public async Task<SubTaskResponseModel> GetById(int id, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            return await _Service.GetAsyncById(id, userId, cancellationToken);
        }

        /// <summary>
        /// Retrieves all subtasks associated with a specific ToDo item.
        /// </summary>
        /// <param name="toDoId">The ID of the ToDo item.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A list of subtasks associated with the ToDo item.</returns>
        [HttpGet("toDoId/{toDoId}")]
        public async Task<List<SubTaskResponseModel>> GetAllByToDoId(int toDoId, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            return await _Service.GetAsyncByToDoId(toDoId, userId, cancellationToken);
        }

        /// <summary>
        /// Creates a new subtask.
        /// </summary>
        /// <param name="subtask">The subtask data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        public async Task Post([FromBody] SubtaskRequestModel subtask, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            await _Service.CreateAsync(subtask.Adapt<SubtaskRequestPostModel>(), userId, cancellationToken);
        }

        /// <summary>
        /// Updates the title of a subtask.
        /// </summary>
        /// <param name="id">The ID of the subtask.</param>
        /// <param name="title">The new title of the subtask.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPut("{id}")]
        public async Task Put(int id, string title, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            await _Service.UpdateAsyncTitle(id, title, userId, cancellationToken);
        }

        /// <summary>
        /// Deletes a subtask by its ID.
        /// </summary>
        /// <param name="id">The ID of the subtask to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            await _Service.DeleteAsync(id, userId, cancellationToken);
        }
    }
}
