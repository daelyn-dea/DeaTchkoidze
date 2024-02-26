namespace PizzaProject.API.Models.Responses.AddressResponses
{
    public class AddressDtoModel
    {
        public int UserId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string? Region { get; set; }
        public string? Description { get; set; }
    }
}
