using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Requests.UserRequests;
using PizzaProject.API.Models.Responses.AddressResponses;
using PizzaProject.API.Models.Responses.UserResponses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.UserExamples
{
    public class UserListDtoExamples : IMultipleExamplesProvider<List<UserDtoModel>>
    {
        public IEnumerable<SwaggerExample<List<UserDtoModel>>> GetExamples()
        {
            yield return SwaggerExample.Create("List of Users", new List<UserDtoModel>
            {
                new UserDtoModel
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
                            Country = "Georgia",
                            Region = "Caucasus",
                            Description = "Libani st.10"
                        },
                        new AddressCreateModel
                        {
                            City = "Gori",
                            Country = "Georgia",
                            Region = "Caucasus",
                            Description = "Libani st.10"
                        }
                    }
                },
                 new UserDtoModel
                {
                    FirstName = "Dea2",
                    LastName = "Tchkoidze2",
                    Email = "chkoidze@gmail.com",
                    PhoneNumber = "567567567",
                    AddressList = new List<AddressCreateModel>
                    {
                        new AddressCreateModel
                        {
                            City = "Tbilisi",
                            Country = "Georgia",
                            Region = "Caucasus",
                            Description = "Libani st.10"
                        },

                    }
                 }
            });
        }
    }
}
