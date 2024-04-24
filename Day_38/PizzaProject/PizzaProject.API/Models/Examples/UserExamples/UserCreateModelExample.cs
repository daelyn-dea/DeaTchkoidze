using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Requests.PizzaRequests;
using PizzaProject.API.Models.Requests.UserRequests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.UserExamples
{
    public class UserCreateModelExample : IExamplesProvider<UserCreateModel>
    {
        public UserCreateModel GetExamples()
        {
            return new UserCreateModel
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
