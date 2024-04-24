using PizzaProject.API.Models.Requests.UserRequests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples.UserExamples
{
    public class UserUpdateModelExample : IExamplesProvider<UserUpdateModel>
    {
        public UserUpdateModel GetExamples()
        {
            return new UserUpdateModel
            {
                FirstName = "Dea",
                LastName = "Tchkoidze",
                Email = "blblabla@gmail.com",
                PhoneNumber = "557300590"
            };
         }
    }
}
