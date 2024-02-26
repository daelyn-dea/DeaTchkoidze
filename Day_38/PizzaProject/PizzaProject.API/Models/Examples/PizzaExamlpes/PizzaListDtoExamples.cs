using PizzaProject.API.Models.Responses.PizzaResponses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.PizzaExamlpes
{
    public class PizzaListDtoExamples : IMultipleExamplesProvider<List<PizzaDtoModel>>
    {
        public IEnumerable<SwaggerExample<List<PizzaDtoModel>>> GetExamples()
        {
            yield return SwaggerExample.Create("List of Pizzas", new List<PizzaDtoModel>
            {
                new PizzaDtoModel
                {
                    Name = "Pepperoni",
                    Price = 19.90M,
                    Description = "Pepperoni is a variety of spicy salami made from cured pork and beef seasoned with paprika and chili peppers.",
                    CaloryCount = 210
                },
                new PizzaDtoModel
                {
                    Name = "Margherita",
                    Price = 15.50M,
                    Description = "Margherita is a classic pizza topped with tomato sauce, fresh mozzarella, basil, and a drizzle of olive oil.",
                    CaloryCount = 180
                },
            });
        }
    }
}
