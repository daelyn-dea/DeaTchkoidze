using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.API.Models.Requests.UserRequests;
using PizzaProject.API.Models.Responses.UserResponses;
using PizzaProject.Application.Users;


namespace PizzaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(IUserService addressService, ILogger<UserController> logger )
        {
            _service = addressService;
            _logger = logger;

            _logger.LogInformation("controller is executed");
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A List representing the users.</returns>
        /// <response code="200">Returns the list of users.</response>
        [HttpGet]
        public async Task<List<UserDtoModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            return result.Adapt<List<UserDtoModel>>();
        }

        /// <summary>
        /// Gets a user by its Id.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to get info about a user by its unique Id. 
        /// </remarks>
        /// <param name="id" example="1">The unique identifier of the user to be updated.</param>
        /// <returns> representing the user.</returns>
        /// <response code="200">Returns the user with the specified Id.</response>
        /// <response code="400">If the user with the specified Id is not found.</response>
        [HttpGet("{id}")]
        public async Task<UserDtoModel> Get(int id, CancellationToken cancellationToken)
        {
            var result = await _service.Get(id, cancellationToken);
            return result.Adapt<UserDtoModel>();
        }

        /// <summary>
        /// Adds an user.
        /// </summary>
        /// <remarks>
        /// Note addresses aren't mandatory
        /// </remarks>
        /// <param name="request">The user creation request.</param>
        /// <param name="userId" example="1">The unique identifier of the user.</param>
        /// <returns>Creates an user. This method does not return any data.</returns>
        /// <response code="200">Indicates that the user was created successfully. There are no return parameters.</response>
        /// <response code="400">If the user is not valid.</response>
        [Produces("application/json")]
        [HttpPost]
        public async Task Post(UserCreateModel request, CancellationToken cancellationToken)
        {
            var model = request.Adapt<UserRequestModel>();

            await _service.Create(model, cancellationToken);
        }

        /// <summary>
        /// Updates the details of a specific address for users.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to modify the properties of an user identified by its unique Id. 
        /// </remarks>
        /// <param name="id" example="1">The unique identifier of the user to be updated.</param>
        /// <returns>A task representing the operation of updating the user. No data is returned.</returns>
        /// <response code="200">Indicates successful update of the user details.</response>
        /// <response code="400">If the provided user update request is invalid or missing required data or Id is not found.</response>
        [Produces("application/json")]
        [HttpPut("{id:int}")]
        public async Task Put([FromRoute] int id, [FromBody] UserUpdateModel request, CancellationToken cancellationToken)
        {
            var model = request.Adapt<UserRequestModel>();

            await _service.Update(id, model, cancellationToken);
        }
        /// <summary>
        /// Deletes a User.
        /// </summary>
        /// <param name="id" example="1" >The Id of user to delete.</param>
        /// <response code="200">Indicates successful deletion of the user from the user's account.</response>
        /// <response code="404">If the user with the specified Id is not found.</response>
        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }
    }
}
