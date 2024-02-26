using PizzaProject.Application.Addresses;
using PizzaProject.Domain.Entity;

namespace PizzaProject.API.Models.Requests.UserRequests
{
    public class UserUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
