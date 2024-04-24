namespace PizzaProject.Application.RankHistories
{
    public interface IRankHistoryService
    {
        Task<RankHistoryResponseModel> Get(int pizzaId, CancellationToken cancellationToken);
        Task Create(RankHistoryRequestModel rank, CancellationToken cancellationToken);
    }
}

