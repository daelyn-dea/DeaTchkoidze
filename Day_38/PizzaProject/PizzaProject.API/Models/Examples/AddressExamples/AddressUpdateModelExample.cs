using PizzaProject.API.Models.Requests.AddressRequests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.AddressExamples
{
    public class AddressUpdateModelExample : IExamplesProvider<AddressUpdateModel>
    {
        public AddressUpdateModel GetExamples()
        {
            return new AddressUpdateModel
            {
                City = "Tbilis",
                Country = "Gerogia",
                Region = "Caucasus",
                Description = "Libani st.10",
            };
        }
    }
}