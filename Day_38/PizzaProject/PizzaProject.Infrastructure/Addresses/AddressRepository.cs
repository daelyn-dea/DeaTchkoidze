using Microsoft.Extensions.Options;
using PizzaProject.Application.Addresses;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;
using PizzaProject.Persistence;
using System.Data.SqlClient;

namespace PizzaProject.Infrastructure.Addresses
{
    public class AddressRepository : IAddressRepository
    {

        private readonly string _connection;

        public AddressRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }
        public async Task<Address> Get(int id, CancellationToken cancellationToken)
        {
            string selectQuery = "select * from Addresses where Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(selectQuery, connection);

                coomand.Parameters.AddWithValue("id", id);

                await connection.OpenAsync(cancellationToken);

                SqlDataReader reader = await coomand.ExecuteReaderAsync(cancellationToken);

                Address createdAddress = null;

                while (await reader.ReadAsync(cancellationToken))
                {
                    createdAddress = new Address
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        City = reader.GetString(2),
                        Country = reader.GetString(3),
                        IsDeleted = reader.GetBoolean(6), // TODO გატესტე არ გჭირდება წესით

                    };
                    if (!reader.IsDBNull(4))
                    {
                        createdAddress.Region = reader.GetString(4);
                    }
                    else
                    {
                        createdAddress.Region = null;
                    }
                    if (!reader.IsDBNull(5))
                    {
                        createdAddress.Description = reader.GetString(5);
                    }
                    else
                    {
                        createdAddress.Description = null;
                    }
                }

                reader.Close();

                return createdAddress;
            }
        }

        public async Task<List<Address>> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            List<Address> adresses = new List<Address>();

            string selectQuery = "select * from Addresses where UserId=@UserId and IsDeleted=0";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(selectQuery, connection);

                coomand.Parameters.AddWithValue("UserId", userId);

                await connection.OpenAsync(cancellationToken);

                SqlDataReader reader = await coomand.ExecuteReaderAsync(cancellationToken);

                while (await reader.ReadAsync(cancellationToken))
                {
                    var createdAddress = new Address
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        City = reader.GetString(2),
                        Country = reader.GetString(3),

                    };
                    if (!reader.IsDBNull(4))
                    {
                        createdAddress.Region = reader.GetString(4);
                    }
                    else
                    {
                        createdAddress.Region = null;
                    }
                    if (!reader.IsDBNull(5))
                    {
                        createdAddress.Description = reader.GetString(5);
                    }
                    else
                    {
                        createdAddress.Description = null;
                    }
                    adresses.Add(createdAddress);
                }

                reader.Close();
                return adresses;
            }
        }

        public async Task Create(Address address, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO Addresses (UserID, City, Country, Region, Description, IsDeleted) VALUES (@UserID, @City, @Country, @Region, @Description, @IsDeleted)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@UserID", address.UserId);
                command.Parameters.AddWithValue("@City", address.City?.Trim());
                command.Parameters.AddWithValue("@Country", address.Country?.Trim());
                if (address.Region != null)
                    command.Parameters.AddWithValue("@Region", address.Region?.Trim());
                else
                    command.Parameters.AddWithValue("@Region", DBNull.Value);
                if (address.Description != null)
                    command.Parameters.AddWithValue("@Description", address.Description.Trim());
                else
                    command.Parameters.AddWithValue("@Description", DBNull.Value);
                command.Parameters.AddWithValue("@IsDeleted", address.IsDeleted);

                await connection.OpenAsync(cancellationToken);

                await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        public async Task Create(List<Address> address, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO Addresses (UserID, City, Country, Region, Description, IsDeleted) VALUES (@UserID, @City, @Country, @Region, @Description, @IsDeleted)";
            for (int j = 0; j < address.Count; j++)
            {
                int i = j;
                using (SqlConnection connection = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(insertQuery, connection);

                    command.Parameters.AddWithValue("@UserID", address[i].UserId);
                    command.Parameters.AddWithValue("@City", address[i].City?.Trim());
                    command.Parameters.AddWithValue("@Country", address[i].Country?.Trim());
                    if (address[i].Region != null)
                        command.Parameters.AddWithValue("@Region", address[i].Region?.Trim());
                    else
                        command.Parameters.AddWithValue("@Region", DBNull.Value);
                    if (address[i].Description != null)
                        command.Parameters.AddWithValue("@Description", address[i].Description.Trim());
                    else
                        command.Parameters.AddWithValue("@Description", DBNull.Value);
                    command.Parameters.AddWithValue("@IsDeleted", address[i].IsDeleted);

                    await connection.OpenAsync(cancellationToken);

                    await command.ExecuteNonQueryAsync(cancellationToken);
                }
            }
        }
        public async Task Update(Address address, CancellationToken cancellationToken)
        {
            string updateQuery = "update Addresses set City=@City, Country=@Country, Region=@Region, Description=@Description where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("Id", address.Id);
                command.Parameters.AddWithValue("City", address.City);
                command.Parameters.AddWithValue("Country", address.Country);
                if (address.Region != null)
                    command.Parameters.AddWithValue("@Region", address.Region);
                else
                    command.Parameters.AddWithValue("@Region", DBNull.Value);
                if (address.Description != null)
                    command.Parameters.AddWithValue("@Description", address.Description);
                else
                    command.Parameters.AddWithValue("@Description", DBNull.Value);
                command.Parameters.AddWithValue("@IsDeleted", address.IsDeleted);

                await connection.OpenAsync(cancellationToken);

                await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            string updateQuery = "update Addresses set IsDeleted=1 where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(updateQuery, connection);

                coomand.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync(cancellationToken);

                await coomand.ExecuteNonQueryAsync(cancellationToken);
            }
        }
        public async Task DeleteByUserId(int userId, CancellationToken cancellationToken)
        {
            string updateQuery = "update Addresses set IsDeleted=1 where UserId = @userId";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(updateQuery, connection);

                coomand.Parameters.AddWithValue("UserId", userId);

                await connection.OpenAsync(cancellationToken);

                await coomand.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        public async Task<bool> ExistsAddressById(int id, CancellationToken cancellationToken)
        {
            string updateQuery = "select Count(*) from Addresses where id = @id and IsDeleted = 0";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync(cancellationToken);

                int count = (int)await command.ExecuteScalarAsync(cancellationToken);

                return count > 0;
            }
        }
        public async Task<bool> ExistsAddressByUserId(int userId, CancellationToken cancellationToken)
        {
            string updateQuery = "select Count(*) from Addresses where UserId = @userId and IsDeleted = 0";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("UserId", userId);

                await connection.OpenAsync(cancellationToken);

                int count = (int)await command.ExecuteScalarAsync(cancellationToken);

                return count > 0;
            }
        }

        public async Task<bool> ExistsAddressByUserIdandId(int id, int userId, CancellationToken cancellationToken)
        {
            string updateQuery = "select Count(*) from Addresses where UserId = @userId and IsDeleted = 0 and id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("UserId", userId);
                command.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync(cancellationToken);

                int count = (int)await command.ExecuteScalarAsync(cancellationToken);

                return count > 0;
            }
        }
    }
}
