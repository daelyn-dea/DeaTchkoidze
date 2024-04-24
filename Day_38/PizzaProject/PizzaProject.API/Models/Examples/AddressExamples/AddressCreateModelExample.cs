using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Requests.PizzaRequests;
using PizzaProject.API.Models.Responses.AddressResponses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.AddressExamples
{
    public class AddressCreateModelExample : IExamplesProvider<AddressCreateModel>
    {
        public AddressCreateModel GetExamples()
        {
            return new AddressCreateModel
            {
                City = "Tbilis",
                Country = "Gerogia",
                Region = "Caucasus",
                Description = "Libani st.10",
            };
         }
    }
}
