using Microsoft.Extensions.Options;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;
using PizzaProject.Persistence;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Infrastructure.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connection;
        private readonly IPizzaRepository _repositoryOfPizza;
        private readonly IAddressRepository _repositoryOfAddress;

        public OrderRepository(IOptions<ConnectionStrings> options, IPizzaRepository repositoryOfPizza, IAddressRepository repositoryOfAddress)
        {
            _connection = options.Value.DefaultConnection;
            _repositoryOfPizza = repositoryOfPizza;
            _repositoryOfAddress = repositoryOfAddress;
        }

        public async Task<List<Order>> GetAll(CancellationToken cancellationToken)
        {
            List<Order> orders = new List<Order>();

            string selectQuery = "select * from Orders";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(selectQuery, connection);

                await connection.OpenAsync();

                SqlDataReader reader = await coomand.ExecuteReaderAsync(cancellationToken);


                while (await reader.ReadAsync())
                {
                    var createdOrder = new Order
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),

                    };
                    if (!reader.IsDBNull(2))
                    {
                        createdOrder.AddressId = reader.GetInt32(2);
                        createdOrder.Address = await _repositoryOfAddress.Get((int)createdOrder.AddressId, cancellationToken);
                    }
                    else
                    {
                        createdOrder.AddressId = null;
                    }
                    createdOrder.PizzasIds = await GetPizzaId(createdOrder.Id, cancellationToken);
                    for (int i = 0; i < createdOrder.PizzasIds.Count; i++)
                    {
                        int j = i;
                        Pizza pizza = await _repositoryOfPizza.Get(createdOrder.PizzasIds[j], cancellationToken);
                        createdOrder.Pizzas.Add(pizza);
                    }
                    orders.Add(createdOrder);
                }

                reader.Close();

                return orders;
            }
        }
        public async Task<Order> Get(int id, CancellationToken cancellationToken)
        {
            string selectQuery = "select * from Orders where Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(selectQuery, connection);

                coomand.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync(cancellationToken);

                SqlDataReader reader = await coomand.ExecuteReaderAsync(cancellationToken);

                Order createdOrder = null;

                while (await reader.ReadAsync(cancellationToken))
                {
                    createdOrder = new Order
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),

                    };
                    if (!reader.IsDBNull(2))
                    {
                        createdOrder.AddressId = reader.GetInt32(2);
                        createdOrder.Address = await _repositoryOfAddress.Get((int)createdOrder.AddressId, cancellationToken);
                    }
                    else
                    {
                        createdOrder.AddressId = null;
                    }
                    createdOrder.PizzasIds = await GetPizzaId(id, cancellationToken);
                    for (int i = 0; i < createdOrder.PizzasIds.Count; i++)
                    {
                        int j = i;
                        Pizza pizza = await _repositoryOfPizza.Get(createdOrder.PizzasIds[j], cancellationToken);
                        createdOrder.Pizzas.Add(pizza);
                    }
                }

                reader.Close();

                return createdOrder;
            }
        }

        private async Task<List<int>?> GetPizzaId(int orderId, CancellationToken cancellationToken)
        {
            string selectQuery = "select * from Basket where OrderId=@orderId";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(selectQuery, connection);

                coomand.Parameters.AddWithValue("OrderId", orderId);

                await connection.OpenAsync(cancellationToken);

                SqlDataReader reader = await coomand.ExecuteReaderAsync(cancellationToken);

                List<int> intList = new List<int>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    intList.Add( reader.GetInt32(2));
                }

                reader.Close();

                return intList;
            }
        }

        public async Task<int> Create(Order order, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO Orders (UserId, AddressId) OUTPUT INSERTED.Id VALUES (@UserId, @AddressId)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@UserId", order.UserId);
                command.Parameters.AddWithValue("@AddressId", order.AddressId);

                await connection.OpenAsync(cancellationToken);

                var generatedId = await command.ExecuteScalarAsync(cancellationToken);

                var orderId = Convert.ToInt32(generatedId);

                return generatedId != null ? Convert.ToInt32(generatedId) : 0;
            }
        }

        public async Task CreateBasket(int orderId, int pizzaId, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO Basket (OrderId, PizzaId) OUTPUT INSERTED.Id VALUES (@OrderId, @PizzaId)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@PizzaId", pizzaId);

                await connection.OpenAsync(cancellationToken);
                await command.ExecuteScalarAsync(cancellationToken);

            }
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            string updateQuery = "select Count(*) from Orders where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync(cancellationToken);

                int count = (int)await command.ExecuteScalarAsync(cancellationToken);

                return count > 0;
            }
        }
    }
}
