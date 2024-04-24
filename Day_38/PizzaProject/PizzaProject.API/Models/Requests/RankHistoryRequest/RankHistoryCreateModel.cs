namespace PizzaProject.API.Models.Requests.RankHistoryRequest
{
    public class RankHistoryCreateModel
    {
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public decimal Rank { get; set; }
    }
}
