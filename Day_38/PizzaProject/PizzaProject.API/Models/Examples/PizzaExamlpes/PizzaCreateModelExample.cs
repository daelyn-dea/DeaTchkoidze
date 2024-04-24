using PizzaProject.API.Models.Requests.PizzaRequests;
using Swashbuckle.AspNetCore.Filters;


namespace PizzaProject.API.Models.Examples.PizzaExamlpes
{
    public class PizzaCreateModelExample : IExamplesProvider<PizzaCreateModel>
    {
        public PizzaCreateModel GetExamples()
        {
            return new PizzaCreateModel
            {
                Name = "Pepperoni",
                Price = 19.90M,
                Description = "Pepperoni is a variety of spicy salami made from cured pork and beef.",
                CaloryCount = 210
            };
        }
    }
}
