using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.API.Models.Examples.PizzaExamlpes;
using PizzaProject.API.Models.Requests.PizzaRequests;
using PizzaProject.API.Models.Responses.PizzaResponses;
using PizzaProject.Application.Pizzas;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly IPizzaService _service;

        public PizzaController(IPizzaService pizzanService, ILogger<PizzaController> logger)
        {
            _service = pizzanService;
            _logger = logger;

            _logger.LogInformation("controller is executed");
        }
        /// <summary>
        /// Gets all Pizzas from the menu.
        /// </summary>
        /// <returns>A List representing the Pizza.</returns>
        /// <response code="200">Returns the list of Pizzas from the menu.</response>
       // [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PizzaDtoModelExample))]
        [HttpGet]
        public async Task<List<PizzaDtoModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            return result.Adapt<List<PizzaDtoModel>>();
        }

        /// <summary>
        /// Gets a Pizza by its Id.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to get info about Pizzas by its unique Id. 
        /// </remarks>
        /// <param name="id" example="1">The unique identifier of the Pizza to be updated.</param>
        /// <returns>A List representing the Pizza.</returns>
        /// <response code="200">Returns the Pizza with the specified Id.</response>
        /// <response code="400">If the Pizza with the specified Id is not found.</response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PizzaDtoModelExamples))]
        [HttpGet("{id}")]
        public async Task<PizzaDtoModel> Get(int id, CancellationToken cancellationToken)
        {
            var result = await _service.Get(id, cancellationToken);
            return result.Adapt<PizzaDtoModel>();
        }

        /// <summary>
        /// Adds a Pizza to the menu.
        /// </summary>
        /// <remarks>
        /// Note description isn't mandatory
        /// </remarks>
        /// <param name="request">The Pizza creation request.</param>
        /// <returns>Creates a Pizza in the menu. This method does not return any data.</returns>
        /// <response code="200">Indicates that the Pizza was created successfully. There are no return parameters.</response>
        /// <response code="400">If the Pizza is not valid.</response>
        [Produces("application/json")]
        [SwaggerRequestExample(typeof(PizzaCreateModel), typeof(PizzaCreateModelExample))]
        [HttpPost]
        public async Task Post(PizzaCreateModel request, CancellationToken cancellationToken)
        {
            var model = request.Adapt<PizzaRequestModel>();

            await _service.Create(model, cancellationToken);
        }

        /// <summary>
        /// Updates the details of a specific Pizza in the menu.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to modify the properties of a Pizza identified by its unique Id. 
        /// </remarks>
        /// <param name="id" example="1">The unique identifier of the Pizza to be updated.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the operation of updating the Pizza. No data is returned.</returns>
        /// <response code="200">Indicates successful update of the Pizza details.</response>
        /// <response code="400">If the provided Pizza update request is invalid or missing required data or Id is not found in the menu.</response>
        [Produces("application/json")]
        [SwaggerRequestExample(typeof(PizzaUpdateModel), typeof(PizzaUpdateModelExample))]
        [HttpPut("{id:int}")]
        public async Task Put([FromRoute] int id, [FromBody] PizzaUpdateModel request, CancellationToken cancellationToken)
        {
            var model = request.Adapt<PizzaRequestModel>();
            
            await _service.Update(id, model, cancellationToken);
        }
        /// /// <summary>
        /// Changes the price of a Pizza by its Id.
        /// </summary>
        /// <param name="id" example="1">The Pizza Id.</param>
        /// <param name="price" example="21.99">The new price.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>No content.</returns>
        /// <response code="200">Indicates successful update of the Pizza price.</response>
        /// <response code="400">If the provided price is invalid.</response>
        [HttpPut("{id:int}/changePrice")]
        public async Task Put(int id, decimal price, CancellationToken cancellationToken)
        {
            await _service.UpdatePrice(id, price, cancellationToken);
        }
        /// <summary>
        /// Deletes a Pizza from the menu.
        /// </summary>
        /// <param name="id" example="1" >The Pizza Id to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <response code="200">Indicates successful deletion of the Pizza from the menu.</response>
        /// <response code="404">If the Pizza with the specified Id is not found.</response>
        [HttpDelete("{id}")]
        public async Task Delete(int id,CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }
    }
}
