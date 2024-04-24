using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Responses.OrderResponses;
using PizzaProject.API.Models.Responses.PizzaResponses;
using PizzaProject.API.Models.Responses.RankHistoryRespons;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.RankHistoryExamples
{
    public class RankHistoryDtoExamples : IMultipleExamplesProvider<RankHistoryDtoModel>
    {
        public IEnumerable<SwaggerExample<RankHistoryDtoModel>> GetExamples()
        {

            yield return SwaggerExample.Create("Rank of Pepperoni", new RankHistoryDtoModel
            {
                Pizza = "Pepperoni",
                Rank = 9.9M,
            });

            yield return SwaggerExample.Create("Rank of Margarita", new RankHistoryDtoModel
            {
                Pizza = "Margarita",
                Rank = 7.6M,
            });
        }

    }
}
