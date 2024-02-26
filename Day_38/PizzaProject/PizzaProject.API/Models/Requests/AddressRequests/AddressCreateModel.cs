namespace PizzaProject.API.Models.Requests.AddressRequests
{
    public class AddressCreateModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string? Region { get; set; }
        public string? Description { get; set; }
    }
}
