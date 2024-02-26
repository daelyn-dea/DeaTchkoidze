using PizzaProject.API.Models.Responses.PizzaResponses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.PizzaExamlpes
{
    public class PizzaDtoModelExamples : IMultipleExamplesProvider<PizzaDtoModel>
    {
        public IEnumerable<SwaggerExample<PizzaDtoModel>> GetExamples()
        {

            yield return SwaggerExample.Create("Pizza 1", new PizzaDtoModel
            {
                Name = "Pepperoni",
                Price = 19.90M,
                Description = "Pepperoni is a variety of spicy salami made from cured pork and beef seasoned",
                CaloryCount = 210
            });
            yield return SwaggerExample.Create("Pizza 2", new PizzaDtoModel
            {
                Name = "Sicilian pizza",
                Price = 29.90M,
                Description = "typically square variety of cheese pizza with dough over an inch thick",
                CaloryCount = 410
            });
        }
    }
}
