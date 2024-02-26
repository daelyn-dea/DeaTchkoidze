using Microsoft.Extensions.Options;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;
using PizzaProject.Persistence;
using System.Data.SqlClient;

namespace PizzaProject.Infrastructure.Pizzas
{
    public class PizzaRepository : IPizzaRepository
    {

        private readonly string _connection;

        public PizzaRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        public async Task<List<Pizza>> GetAll(CancellationToken cancellationToken)
        {
            List<Pizza> pizzas = new List<Pizza>();

            string selectQuery = "select * from Pizzas where IsDeleted = 0";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(selectQuery, connection);

                await connection.OpenAsync();

                SqlDataReader reader = await coomand.ExecuteReaderAsync(cancellationToken);


                while (await reader.ReadAsync())
                {
                    var createdPizzas = new Pizza
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        CaloryCount = reader.GetInt32(4),
                       // IsDeleted = reader.GetBoolean(5),

                    };
                    if (!reader.IsDBNull(3))
                    {
                        createdPizzas.Description = reader.GetString(3);
                    }
                    else
                    {
                        createdPizzas.Description = null;
                    }
                    pizzas.Add(createdPizzas);
                }

                reader.Close();

                return pizzas;
            }
        }
        public async Task<Pizza> Get(int id, CancellationToken cancellationToken)
        {
            string selectQuery = "select * from Pizzas where Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(selectQuery, connection);

                coomand.Parameters.AddWithValue("id", id);

                await connection.OpenAsync(cancellationToken);

                SqlDataReader reader = await coomand.ExecuteReaderAsync(cancellationToken);

                Pizza createdPizzas = null;

                while (await reader.ReadAsync(cancellationToken))
                {
                    createdPizzas = new Pizza
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        CaloryCount = reader.GetInt32(4),
                        IsDeleted = reader.GetBoolean(5),

                    };
                    if (!reader.IsDBNull(3))
                    {
                        createdPizzas.Description = reader.GetString(3);
                    }
                    else
                    {
                        createdPizzas.Description = null;
                    }
                }

                reader.Close();

                return createdPizzas;
            }
        }

        public async Task Create(Pizza pizza, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO Pizzas (Name, Price, Description, CaloryCount, IsDeleted) VALUES (@Name, @Price, @Description, @CaloryCount, @IsDeleted)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@Name", pizza.Name);
                command.Parameters.AddWithValue("@Price", pizza.Price);
                if (pizza.Description != null)
                     command.Parameters.AddWithValue("@Description", pizza.Description);
                else
                    command.Parameters.AddWithValue("@Description", DBNull.Value);
                command.Parameters.AddWithValue("@CaloryCount", pizza.CaloryCount);
                command.Parameters.AddWithValue("@IsDeleted", pizza.IsDeleted);

                await connection.OpenAsync(cancellationToken);

                await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        public async Task Update(Pizza pizza, CancellationToken cancellationToken)
        {
            string updateQuery = "update Pizzas set Name=@Name, Price=@Price,Description=@Description, CaloryCount=@CaloryCount where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("Id", pizza.Id);
                command.Parameters.AddWithValue("Name", pizza.Name);
                command.Parameters.AddWithValue("Price", pizza.Price);
                if (pizza.Description != null)
                    command.Parameters.AddWithValue("@Description", pizza.Description);
                else
                    command.Parameters.AddWithValue("@Description", DBNull.Value);
                command.Parameters.AddWithValue("CaloryCount", pizza.CaloryCount);
                command.Parameters.AddWithValue("@IsDeleted", pizza.IsDeleted);

                await connection.OpenAsync(cancellationToken);

                await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        public async Task UpdatePrice(int id, decimal price, CancellationToken cancellationToken)
        {
            string updateQuery = "update Pizzas set Price=@Price where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(updateQuery, connection);

                coomand.Parameters.AddWithValue("Id", id);
                coomand.Parameters.AddWithValue("Price", price);

                await connection.OpenAsync(cancellationToken);

                await coomand.ExecuteNonQueryAsync(cancellationToken);
            }
        }
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            string updateQuery = "update Pizzas set IsDeleted=1 where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(updateQuery, connection);

                coomand.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync(cancellationToken);

                await coomand.ExecuteNonQueryAsync(cancellationToken);
            }
        }
        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            string updateQuery = "select Count(*) from Pizzas where id = @id and IsDeleted = 0";

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
