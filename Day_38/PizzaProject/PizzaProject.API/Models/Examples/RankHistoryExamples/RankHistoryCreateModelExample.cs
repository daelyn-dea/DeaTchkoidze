using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Requests.RankHistoryRequest;
using PizzaProject.API.Models.Requests.UserRequests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.RankHistoryExamples
{
    public class RankHistoryCreateModelExample : IExamplesProvider<RankHistoryCreateModel>
    {
        public RankHistoryCreateModel GetExamples()
        {
            return new RankHistoryCreateModel
            {
                UserId = 2,
                PizzaId = 9,
                Rank = 10,
            };
        }
    }
}
