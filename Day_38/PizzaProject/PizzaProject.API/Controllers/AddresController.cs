using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.API.Models.Examples.AddressExamples;
using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Responses.AddressResponses;
using PizzaProject.Application.Addresses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _service;

        public AddressController(IAddressService addressService, ILogger<AddressController> logger)
        {
            _service = addressService;
            _logger = logger;

            _logger.LogInformation("controller is executed");
        }

        /// <summary>
        /// Gets a Address by its Id.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to get info about Address by its unique Id. 
        /// </remarks>
        /// <param name="id" example="1">The unique identifier of the Address to be updated.</param>
        /// <returns> representing the Address.</returns>
        /// <response code="200">Returns the Address with the specified Id.</response>
        /// <response code="400">If the Address with the specified Id is not found.</response>
       // [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AddressDtoExamples))]
        [HttpGet("{id}")]
        public async Task<AddressDtoModel> Get(int id, CancellationToken cancellationToken)
        {
            var result = await _service.Get(id, cancellationToken);
            return result.Adapt<AddressDtoModel>();
        }

        /// <summary>
        /// Adds a Address into Users account.
        /// </summary>
        /// <remarks>
        /// Note description and region aren't mandatory
        /// </remarks>
        /// <param name="request">The Address creation request.</param>
        /// <param name="userId" example="1">The unique identifier of the User for address create.</param>
        /// <returns>Creates a Address into users account. This method does not return any data.</returns>
        /// <response code="200">Indicates that the Address was created successfully. There are no return parameters.</response>
        /// <response code="400">If the Address is not valid.</response>
        [Produces("application/json")]
        //[SwaggerRequestExample(typeof(AddressCreateModel), typeof(AddressCreateModelExample))]
        [HttpPost]
        public async Task Post(AddressCreateModel request, int userId, CancellationToken cancellationToken)
        {
            var model = request.Adapt<AddressRequestModel>();

            await _service.Create(model, userId, cancellationToken);
        }

        /// <summary>
        /// Updates the details of a specific Address for users.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to modify the properties of a Address identified by its unique Id. 
        /// </remarks>
        /// <param name="id" example="1">The unique identifier of the Address to be updated.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the operation of updating the Address. No data is returned.</returns>
        /// <response code="200">Indicates successful update of the Address details.</response>
        /// <response code="400">If the provided Address update request is invalid or missing required data or Id is not found.</response>
        [Produces("application/json")]
        //[SwaggerRequestExample(typeof(AddressUpdateModel), typeof(AddressUpdateModelExample))]
        [HttpPut("{id:int}")]
        public async Task Put([FromRoute] int id, [FromBody] AddressUpdateModel request, CancellationToken cancellationToken)
        {
            var model = request.Adapt<AddressRequestModel>();

            await _service.Update(id, model, cancellationToken);
        }
        /// <summary>
        /// Deletes a Address.
        /// </summary>
        /// <param name="id" example="1" >The Address Id to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <response code="200">Indicates successful deletion of the Address from the user's account.</response>
        /// <response code="404">If the Address with the specified Id is not found.</response>
        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }
    }
}
