using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.API.Models.Examples.PizzaExamlpes;
using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Requests.OrderRequest;
using PizzaProject.API.Models.Requests.UserRequests;
using PizzaProject.API.Models.Responses.AddressResponses;
using PizzaProject.API.Models.Responses.OrderResponses;
using PizzaProject.API.Models.Responses.PizzaResponses;
using PizzaProject.API.Models.Responses.UserResponses;
using PizzaProject.Application.Addresses;
using PizzaProject.Application.Orders;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _service;

        public OrderController(IOrderService addressService, ILogger<OrderController> logger)
        {
            _service = addressService;
            _logger = logger;

            _logger.LogInformation("controller is executed");
        }

        /// <summary>
        /// Gets all Orders.
        /// </summary>
        /// <returns>A List representing the Orders.</returns>
        /// <response code="200">Returns the list of Orders.</response>
        [HttpGet]
        public async Task<List<OrderDtoModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            return result.Adapt<List<OrderDtoModel>>();
        }

        /// <summary>
        /// Gets an Order by its Id.
        /// </summary>
        /// <param name="id" example="1">The unique identifier of the Order to be retrieved.</param>
        /// <returns>A representation of the Order.</returns>
        /// <response code="200">Returns the Order with the specified Id.</response>
        /// <response code="400">If the Order with the specified Id is not found.</response>
        [HttpGet("{id}")]
        public async Task<OrderDtoModel> Get(int id, CancellationToken cancellationToken)
        {
            var result = await _service.Get(id, cancellationToken);
            return result.Adapt<OrderDtoModel>();
        }

        /// <summary>
        /// Creates a new Order.
        /// </summary>
        /// <param name="order">The Order creation request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Creates a new Order. This method does not return any data.</returns>
        /// <response code="200">Indicates that the Order was created successfully. There are no return parameters.</response>
        /// <response code="400">If the Order is not valid.</response>
        [Produces("application/json")]
        [HttpPost]
        public async Task Post(OrderCreateModel order, CancellationToken cancellationToken)
        {
            var result = order.Adapt<OrderRequestModel>();
            await _service.Create(result, cancellationToken);
        }
    }
}
