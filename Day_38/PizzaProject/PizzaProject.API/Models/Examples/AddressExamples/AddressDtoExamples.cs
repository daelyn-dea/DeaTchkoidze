using PizzaProject.API.Models.Responses.AddressResponses;
using PizzaProject.API.Models.Responses.PizzaResponses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.AddressExamples
{
    public class AddressDtoExamples : IMultipleExamplesProvider<AddressDtoModel>
    {
        IEnumerable<SwaggerExample<AddressDtoModel>> IMultipleExamplesProvider<AddressDtoModel>.GetExamples()
        {
            yield return SwaggerExample.Create("Address 1", new AddressDtoModel
            {
                UserId = 1,
                City = "Tbilis",
                Country = "Gerogia",
                Region = "Caucasus",
                Description = "Libani st.10",
            });

            yield return SwaggerExample.Create("Address 2", new AddressDtoModel
            {
                UserId = 1,
                City = "Tbilis",
                Country = "Gerogia",
            });
        }
    }
 }