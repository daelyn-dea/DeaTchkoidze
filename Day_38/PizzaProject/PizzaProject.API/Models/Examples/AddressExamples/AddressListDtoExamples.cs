using PizzaProject.API.Models.Responses.AddressResponses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.AddressExamples
{
    public class AddressListDtoExamples : IMultipleExamplesProvider<List<AddressDtoModel>>
    {
        public IEnumerable<SwaggerExample<List<AddressDtoModel>>> GetExamples()
        {
            yield return SwaggerExample.Create("List of Addresses", new List<AddressDtoModel>
            {
                new AddressDtoModel
                {
                    UserId = 1,
                    City = "Tbilisi",
                    Country = "Georgia",
                    Region = "Caucasus",
                    Description = "Libani st.10",
                },
                new AddressDtoModel
                {
                    UserId = 1,
                    City = "Tbilisi",
                    Country = "Georgia",
                },
                 new AddressDtoModel
                {
                    UserId = 1,
                    City = "gori",
                    Country = "Georgia",
                },
            });
        }
    }
}
