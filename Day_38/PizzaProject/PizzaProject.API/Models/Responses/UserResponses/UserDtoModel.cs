using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.Application.Addresses;
using PizzaProject.Domain.Entity;

namespace PizzaProject.API.Models.Responses.UserResponses
{
    public class UserDtoModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<AddressCreateModel> AddressList { get; set; }
    }
}
