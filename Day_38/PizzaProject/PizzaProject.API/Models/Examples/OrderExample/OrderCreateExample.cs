using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Requests.OrderRequest;
using PizzaProject.API.Models.Requests.PizzaRequests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.OrderExample
{
    public class OrderCreateExample : IExamplesProvider<OrderCreateModel>
    {
        public OrderCreateModel GetExamples()
        {
            return new OrderCreateModel
            {
                UserId = 1,
                AddressId = 1,
                PizzasIds = new List<int>
                {
                 1,2,3,4
                }
            };
        }
    }
}