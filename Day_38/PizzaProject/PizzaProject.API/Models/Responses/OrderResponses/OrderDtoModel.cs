using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Responses.AddressResponses;
using PizzaProject.API.Models.Responses.PizzaResponses;
using PizzaProject.API.Models.Responses.UserResponses;

namespace PizzaProject.API.Models.Responses.OrderResponses
{
    public class OrderDtoModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<PizzaDtoModel> Pizzas { get; set; }
        public AddressCreateModel Address { get; set; }
    }
}
