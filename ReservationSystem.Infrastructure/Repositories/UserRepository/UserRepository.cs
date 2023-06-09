﻿using Microsoft.Data.SqlClient;
using ReservationSystem.Domain.Entities;
using ReservationSystem.Infrastructure.Data;
using System.Data;

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
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"SELECT * FROM Users WHERE IsDeleted = 0";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            var dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);

                            var users = new List<User>() { };

                            foreach (DataRow row in dataTable.Rows)
                            {
                                users.Add(new User
                                {
                                    Id = (int)row["Id"],
                                    CompleteName = row["CompleteName"].ToString()!,
                                    PhoneNumber = row["PhoneNumber"].ToString()!,
                                });
                            }
                            return users;
                        }

                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Method to get user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"SELECT * FROM Users WHERE Id = @Id and IsDeleted = 0";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            var dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);

                            var users = new List<User>() { };

                            foreach (DataRow row in dataTable.Rows)
                            {
                                users.Add(new User
                                {
                                    Id = (int)row["Id"],
                                    CompleteName = row["CompleteName"].ToString()!,
                                    PhoneNumber = row["PhoneNumber"].ToString()!,
                                });
                            }
                            return users[0];
                        }

                    }
                }
            }
            catch (Exception)
            {
                return null;
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
