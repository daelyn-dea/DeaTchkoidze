using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Responses.AddressResponses;
using PizzaProject.API.Models.Responses.OrderResponses;
using PizzaProject.API.Models.Responses.PizzaResponses;
using PizzaProject.API.Models.Responses.UserResponses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.OrderExample
{
    public class OrderDtoModelExamples : IMultipleExamplesProvider<OrderDtoModel>
    {
        public IEnumerable<SwaggerExample<OrderDtoModel>> GetExamples()
        {

            yield return SwaggerExample.Create("Order 1", new OrderDtoModel
            {
                Id = 1,
                UserId = 1,
                Pizzas = new List<PizzaDtoModel>
            {
                new PizzaDtoModel
                {
                    Name = "Pepperoni Pizza",
                    Price = 10.99m,
                    Description = "Delicious Pizza",
                    CaloryCount = 800
                },
                 new PizzaDtoModel
                {
                    Name = "Margarita Pizza",
                    Price = 10.99m,
                    Description = "Delicious Pizza",
                    CaloryCount = 400
                }
            },
                Address = new AddressCreateModel
                {
                    City = "Tbilisi",
                    Country = "Georgia",
                    Region = "Caucasus",
                    Description = "avchalashi var brt"
                }
            });
            yield return SwaggerExample.Create("Order 2", new OrderDtoModel
            {
                Id = 1,
                UserId = 1,
                Pizzas = new List<PizzaDtoModel>
            {
                new PizzaDtoModel
                {
                    Name = "Pepperoni Pizza",
                    Price = 10.99m,
                    Description = "Delicious Pizza",
                    CaloryCount = 800
                },
            },
            });
        }

    }
}
