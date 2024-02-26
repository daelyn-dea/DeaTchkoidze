using Microsoft.Extensions.Options;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;
using PizzaProject.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connection;
        private readonly IAddressRepository _repository;

        public UserRepository(IOptions<ConnectionStrings> options, IAddressRepository repository )
        {
            _connection = options.Value.DefaultConnection;
            _repository = repository;
        }
        public async Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            List<User> users = new List<User>();

            string selectQuery = "select * from Users where IsDeleted = 0";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);


                while (await reader.ReadAsync())
                {
                    var createdUser = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                    };
                    createdUser.AddressList = _repository.GetByUserId(createdUser.Id, cancellationToken).Result;
                    users.Add(createdUser);
                }

                reader.Close();

                return users;
            }

        }

        public async Task<User> Get(int id, CancellationToken cancellationToken)
        {
            string selectQuery = "select * from Users where Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(selectQuery, connection);

                coomand.Parameters.AddWithValue("id", id);

                await connection.OpenAsync(cancellationToken);

                SqlDataReader reader = await coomand.ExecuteReaderAsync(cancellationToken);

                User createdUser = null;

                while (await reader.ReadAsync(cancellationToken))
                {
                     createdUser = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                    };
                    createdUser.AddressList = _repository.GetByUserId(createdUser.Id, cancellationToken).Result;
                }

                reader.Close();

                return createdUser;
            }
        }

        public async Task<int> Create(User user, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO Users (FirstName, LastName, Email, PhoneNumber, IsDeleted) OUTPUT INSERTED.Id VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @IsDeleted)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@IsDeleted", user.IsDeleted);

                await connection.OpenAsync(cancellationToken);

                var generatedId = await command.ExecuteScalarAsync(cancellationToken);

                return generatedId != null ? Convert.ToInt32(generatedId) : 0;
            }
        }




        public async Task Update(User user, CancellationToken cancellationToken)
        {
            string updateQuery = "update Users set FirstName=@FirstName, LastName=@LastName,Email=@Email, PhoneNumber=@PhoneNumber where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("Id", user.Id);
                command.Parameters.AddWithValue("FirstName", user.FirstName);
                command.Parameters.AddWithValue("LastName", user.LastName);
                command.Parameters.AddWithValue("Email", user.Email);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);

                await connection.OpenAsync(cancellationToken);

                await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            string updateQuery = "update Users set IsDeleted=1 where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand coomand = new SqlCommand(updateQuery, connection);

                coomand.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync(cancellationToken);

                await coomand.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        public async Task<bool> ExistsUserById(int id, CancellationToken cancellationToken)
        {
            string updateQuery = "select Count(*) from Users where id = @id and IsDeleted = 0";

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
