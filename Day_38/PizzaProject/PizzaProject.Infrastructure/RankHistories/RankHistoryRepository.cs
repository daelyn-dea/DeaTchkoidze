using Microsoft.Extensions.Options;
using PizzaProject.Application.RankHistories;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;
using PizzaProject.Persistence;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Infrastructure.RankHistories
{
    public class RankHistoryRepository : IRankHistoryRepository
    {
        private readonly string _connection;
        private readonly IPizzaRepository _pizzaRepository;
        public RankHistoryRepository(IOptions<ConnectionStrings> options, IPizzaRepository pizzaRepository)
        {
            _connection = options.Value.DefaultConnection;
            _pizzaRepository = pizzaRepository;
        }
        public async Task Create(RankHistory Rank, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO RankHistory (UserId, PizzaId, Rank) OUTPUT INSERTED.Id VALUES (@UserId, @PizzaId, @Rank)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@UserId", Rank.UserId);
                command.Parameters.AddWithValue("@PizzaId", Rank.PizzaId);
                command.Parameters.AddWithValue("@Rank", Rank.Rank);

                await connection.OpenAsync(cancellationToken);

                var generatedId = await command.ExecuteScalarAsync(cancellationToken);
            }
        }

        public async Task<RankHistoryResponseModel> Get(int pizzaId, CancellationToken cancellationToken)
        {
            string selectQuery = "SELECT AVG(Rank) FROM RankHistory WHERE PizzaId = @PizzaId";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@PizzaId", pizzaId);

                await connection.OpenAsync(cancellationToken);

                var averageRank = await command.ExecuteScalarAsync(cancellationToken);

                if (averageRank != null && decimal.TryParse(averageRank.ToString(), out decimal result))
                {
                    var pizza =  await _pizzaRepository.Get(pizzaId, cancellationToken);
                    RankHistoryResponseModel rankHistoryResponseModel = new RankHistoryResponseModel();
                    rankHistoryResponseModel.Rank = result;
                    rankHistoryResponseModel.PizzaId = pizzaId;
                    rankHistoryResponseModel.Pizza = pizza.Name;
                    return rankHistoryResponseModel;
                }

                return null;
            }
        }

        public async Task<bool> ExistsRankByUserIdAndPizzaId(int userId, int pizzaId, CancellationToken cancellationToken)
        {
            string existsQuery = "SELECT COUNT(*) FROM [PizzaProject].[dbo].[Orders] AS O " +
                     "JOIN [PizzaProject].[dbo].[Basket] AS B ON O.Id = B.OrderId " +
                     "WHERE O.UserId = @userId AND B.PizzaId = @pizzaId";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(existsQuery, connection);

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@pizzaId", pizzaId);

                await connection.OpenAsync(cancellationToken);

                int count = (int)await command.ExecuteScalarAsync(cancellationToken);

                return count > 0;
            }
        }
    }
}
