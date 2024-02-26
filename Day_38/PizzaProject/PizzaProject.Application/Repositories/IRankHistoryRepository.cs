using PizzaProject.Application.RankHistories;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Repositories
{
    public  interface IRankHistoryRepository
    {
        Task<RankHistoryResponseModel> Get(int pizzaId, CancellationToken cancellationToken);
        Task Create(RankHistory Rank, CancellationToken cancellationToken);
        Task<bool> ExistsRankByUserIdAndPizzaId(int userId, int pizzaId, CancellationToken cancellationToken);
    }
}
