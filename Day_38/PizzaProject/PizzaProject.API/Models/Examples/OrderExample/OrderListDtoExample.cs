using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Responses.AddressResponses;
using PizzaProject.API.Models.Responses.OrderResponses;
using PizzaProject.API.Models.Responses.PizzaResponses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.OrderExample
{
    public class OrderListDtoModelExamples : IMultipleExamplesProvider<List<OrderDtoModel>>
    {
        public IEnumerable<SwaggerExample<List<OrderDtoModel>>> GetExamples()
        {
            yield return SwaggerExample.Create("List of Orders", new List<OrderDtoModel>
            {
                new OrderDtoModel
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
                },
                new OrderDtoModel
                {
                    Id = 2,
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
                },
            });
        }
    }
}
