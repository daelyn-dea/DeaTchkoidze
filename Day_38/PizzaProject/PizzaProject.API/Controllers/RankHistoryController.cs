using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.API.Models.Examples.PizzaExamlpes;
using PizzaProject.API.Models.Requests.PizzaRequests;
using PizzaProject.API.Models.Requests.RankHistoryRequest;
using PizzaProject.API.Models.Responses.RankHistoryRespons;
using PizzaProject.API.Models.Responses.UserResponses;
using PizzaProject.Application.Pizzas;
using PizzaProject.Application.RankHistories;
using PizzaProject.Application.Users;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankHistoryController : ControllerBase
    {
        private readonly ILogger<RankHistoryController> _logger;
        private readonly IRankHistoryService _service;

        public RankHistoryController(IRankHistoryService rankService, ILogger<RankHistoryController> logger)
        {
             _service = rankService;
             _logger = logger;

             _logger.LogInformation("controller is executed");
         }
    
        /// <summary>
        /// Gets a Rank by Pizza Id.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to get info about Rankign by Pizza Id. 
        /// </remarks>
        /// <param name="id" example="1">The unique identifier of the Pizza.</param>
        /// <returns> representing the rank.</returns>
        /// <response code="200">Returns the Rank and name of Pizza with the specified Pizza Id.</response>
        /// <response code="400">If the Pizza with the specified Id is not found.</response>
        [HttpGet("{id}")]
        public async Task<RankHistoryDtoModel> Get(int id, CancellationToken cancellationToken)
        {
            var result = await _service.Get(id, cancellationToken);
            return result.Adapt<RankHistoryDtoModel>();
        }

        /// <summary>
        /// Adds a Rank to the Pizza.
        /// </summary>
        /// <param name="request">The Rank request.</param>
        /// <returns>Creates a Rank in the Pizza. This method does not return any data.</returns>
        /// <response code="200">Indicates that the Rank was created successfully. There are no return parameters.</response>
        /// <response code="400">If the Rank is not valid.</response>
        [HttpPost]
        public async Task Post(RankHistoryCreateModel request, CancellationToken cancellationToken)
        {
            var model = request.Adapt<RankHistoryRequestModel>();

            await _service.Create(model, cancellationToken);
        }

    }
}
