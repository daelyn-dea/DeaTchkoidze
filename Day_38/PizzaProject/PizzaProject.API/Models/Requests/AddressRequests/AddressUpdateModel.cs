namespace PizzaProject.API.Models.Requests.AddressRequests
{
    public class AddressUpdateModel
    {
        //  public int UserId { get; set; } //TODO : ცალკე მაინიჭე და გამოიძახე იუზერზე შექმნა
        public string City { get; set; }
        public string Country { get; set; }
        public string? Region { get; set; }
        public string? Description { get; set; }
    }
}
