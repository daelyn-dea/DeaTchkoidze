using PizzaProject.Application.Addresses;

namespace PizzaProject.Application.Users
{
    public class UserResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<AddressResponseModel> AddressList { get; set; }
    }
}
