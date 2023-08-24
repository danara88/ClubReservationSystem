using Microsoft.Data.SqlClient;
using ReservationSystem.Domain.Entities;
using ReservationSystem.Infrastructure.Data;

namespace ReservationSystem.Infrastructure.Repositories
{
    /// <summary>
    /// User repository
    /// </summary>
    public class UserRepository : IUserRepository
    {

        private readonly string _connectionString = ConnectionSettings.CONNECTION_STRING;

        public UserRepository()
        {
        }

        /// <summary>
        /// Method to create a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Create(User user)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"INSERT INTO Users (CompleteName,PhoneNumber) 
                                    VALUES(@CompleteName,@PhoneNumber)";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@CompleteName", user.CompleteName));
                        sqlCommand.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber));
                        int affectedArrows = sqlCommand.ExecuteNonQuery();
                        if (affectedArrows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to delete a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"UPDATE Users SET IsDeleted = 1 WHERE Id = @Id and IsDeleted = 0";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@Id", id));
                        int affectedArrows = sqlCommand.ExecuteNonQuery();
                        if (affectedArrows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to get all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            var users = new List<User>() { };
            string query = @"SELECT Id, CompleteName, PhoneNumber FROM Users WHERE IsDeleted = 0";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        var user = new User()
                        {
                            Id = reader.GetInt32(0),
                            CompleteName = reader.GetString(1),
                            PhoneNumber = reader.GetString(2)
                        };
                        users.Add(user);
                    }

                    reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Something went wrong while connecting to database. {ex.Message}");
                }
            }
            return users;
        }

        /// <summary>
        /// Method to get user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            string query = @"SELECT Id, CompleteName, PhoneNumber FROM Users WHERE Id = @Id and IsDeleted = 0";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@Id", id));

                try
                {
                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Read();
                   
                    var user = new User()
                    {
                        Id = reader.GetInt32(0),
                        CompleteName = reader.GetString(1),
                        PhoneNumber = reader.GetString(2)
                    };

                    reader.Close();
                    sqlConnection.Close();

                    return user;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Something went wrong while connecting to database. {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Method to update a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(User user)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"UPDATE Users
                                         SET CompleteName = @CompleteName, 
                                             PhoneNumber = @PhoneNumber
                                             WHERE Id = @Id and IsDeleted = 0";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@Id", user.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@CompleteName", user.CompleteName));
                        sqlCommand.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber));
                        
                        int affectedArrows = sqlCommand.ExecuteNonQuery();
                        if (affectedArrows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
