using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Requests.UserRequests;
using PizzaProject.API.Models.Responses.UserResponses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.UserExamples
{
    public class UserDtoModelExample : IExamplesProvider<UserDtoModel>
    {
        public UserDtoModel GetExamples()
        {
            return new UserDtoModel
            {
                FirstName = "Dea",
                LastName = "Tchkoidze",
                Email = "chkoidze@gmail.com",
                PhoneNumber = "567567567",
                AddressList = new List<AddressCreateModel>
                {
                      new AddressCreateModel
                    {
                        City = "Tbilisi",
                        Country = "Gerogia",
                        Region = "Caucasus",
                        Description = "Libani st.10",
                    },
                      new AddressCreateModel
                    {
                        City = "Gori",
                        Country = "Gerogia",
                        Region = "Caucasus",
                        Description = "Libani st.10",
                    },
                }
            };
        }
    }
}

