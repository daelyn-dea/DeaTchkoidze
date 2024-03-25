using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using ToDo.API.Infrastructure.Authentication;
using ToDo.API.Infrastructure.Models.StatusEnumModel;
using ToDo.API.Infrastructure.Models.ToDoItemModels;
using ToDo.Application.ToDos;
using ToDo.Application.ToDos.RequestModel;
using ToDo.Application.ToDos.ResponseModel;
using ToDo.Application.ToDos.ToDoItemRequestModel;
using ToDo.Application.Users;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.ToDos;
using static ToDo.API.Infrastructure.Models.StatusEnumModel.StatusEnums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class todosController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        private readonly IOptions<AuthenticationConfiguration> _authOptions;
        public todosController(IToDoService toDoService, IOptions<AuthenticationConfiguration> authOptions)
        {
            _toDoService = toDoService;
            _authOptions = authOptions;
        }

        /// <summary>
        /// Get all todo items.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A list of todo items.</returns>
        [HttpGet]
        public async Task<List<ToDoItemResponseModel>> Get(CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            return await _toDoService.GetAllAsyncByOwnerId(userId, cancellationToken);
        }

        /// <summary>
        /// Get a todo item by ID.
        /// </summary>
        /// <param name="id">The ID of the todo item.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The todo item.</returns>
        [HttpGet("{id}")]
        public async Task<ToDoItemResponseModel> GetById(int id, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            return await _toDoService.GetAsync(id, userId, cancellationToken);
        }
        /// <summary>
        /// Get a todo item by Status.
        /// </summary>
        /// <param name="status">The status of the todo item.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The todo item.</returns>
        [HttpGet("status/{status}")]
        public async Task<List<ToDoItemResponseModel>> GetByStatus(Statuses status, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            return await _toDoService.GetAsyncByStatus(status.Adapt<Status>(), userId, cancellationToken);
        }

        /// <summary>
        /// Create a new todo item.
        /// </summary>
        /// <param name="todo">The todo item to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        public async Task Post([FromBody] ToDoItemPostModel todo, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            var toDoItem = todo.Adapt<ToDoItemRequestPostModel>();
            toDoItem.OwnerId = userId;
            await _toDoService.CreateAsync(toDoItem, cancellationToken);
        }

        /// <summary>
        /// Done a new todo item.
        /// </summary>
        /// <param name="id">The todo item id to done.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost("{id}/done")]
        public async Task Post(int id, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            await _toDoService.UpdateAsyncStatus(id, userId, cancellationToken);
        }

        /// <summary>
        /// Update a todo item by ID.
        /// </summary>
        /// <param name="id">The ID of the todo item.</param>
        /// <param name="todo">The updated todo item data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPatch("{id}")]
        public async Task Patch(int id, [FromBody] ToDoItemPatchModel todo, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            var todomodel = todo.Adapt<ToDoItemRequestPatchModel>();
            todomodel.id = id;
            todomodel.OwnerId = userId;
            await _toDoService.PatchAsync(todomodel, cancellationToken);
        }

        /// <summary>
        /// Delete a todo item by ID.
        /// </summary>
        /// <param name="id">The ID of the todo item.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            await _toDoService.DeleteAsync(id, userId, cancellationToken);
        }
    }
}
