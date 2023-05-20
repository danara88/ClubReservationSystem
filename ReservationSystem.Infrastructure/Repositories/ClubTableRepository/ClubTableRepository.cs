using Microsoft.Data.SqlClient;
using ReservationSystem.Domain.Entities;
using ReservationSystem.Infrastructure.Data;
using System.Data;

namespace ReservationSystem.Infrastructure.Repositories
{
    /// <summary>
    /// ClubTable repository
    /// </summary>
    public class ClubTableRepository : IClubTableRepository
    {
        private readonly string _connectionString = ConnectionSettings.CONNECTION_STRING;

        public ClubTableRepository()
        {
        }

        /// <summary>
        /// Method to create a club table
        /// </summary>
        /// <param name="clubTable"></param>
        /// <returns>Task<bool></returns>
        public bool Create(ClubTable clubTable)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"INSERT INTO ClubTables(CategoryName,MinConsumption,Capacity,TotalAvailable) 
                                    VALUES(@CategoryName,@MinConsumption,@Capacity,@TotalAvailable)";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@CategoryName", clubTable.CategoryName));
                        sqlCommand.Parameters.Add(new SqlParameter("@MinConsumption", clubTable.MinConsumption));
                        sqlCommand.Parameters.Add(new SqlParameter("@Capacity", clubTable.Capacity));
                        sqlCommand.Parameters.Add(new SqlParameter("@TotalAvailable", clubTable.TotalAvailable));
                        int affectedArrows = sqlCommand.ExecuteNonQuery();
                        if(affectedArrows > 0) 
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
        /// Method to delete a club table by ID
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
                    var query = @"UPDATE ClubTables SET IsDeleted = 1 WHERE Id = @Id and IsDeleted = 0";
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
        /// Method to get all club tables
        /// </summary>
        /// <returns></returns>
        public List<ClubTable> GetAll()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"SELECT * FROM ClubTables WHERE IsDeleted = 0";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            var dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);

                            var clubTables = new List<ClubTable>() { };

                            foreach (DataRow row in dataTable.Rows)
                            {
                                clubTables.Add(new ClubTable
                                {
                                    Id = (int)row["Id"],
                                    CategoryName = row["CategoryName"].ToString()!,
                                    MinConsumption = (decimal)row["MinConsumption"],
                                    Capacity = (int)row["Capacity"],
                                    TotalAvailable = (int)row["TotalAvailable"]
                                });
                            }
                            return clubTables;
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
        /// Method to get a club table by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClubTable GetById(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"SELECT * FROM ClubTables WHERE Id = @Id and IsDeleted = 0";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                        using (SqlDataAdapter  sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            var dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);

                            var clubTables = new List<ClubTable>() { };

                            foreach (DataRow row in dataTable.Rows)
                            {
                                clubTables.Add(new ClubTable
                                {
                                    Id = (int)row["Id"],
                                    CategoryName = row["CategoryName"].ToString()!,
                                    MinConsumption = (decimal)row["MinConsumption"],
                                    Capacity = (int)row["Capacity"],
                                    TotalAvailable = (int)row["TotalAvailable"]
                                });
                            }
                            return clubTables[0];
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
        /// Method to update a club table
        /// </summary>
        /// <param name="clubTable"></param>
        /// <returns></returns>
        public bool Update(ClubTable clubTable)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"UPDATE ClubTables
                                         SET CategoryName = @CategoryName, 
                                             MinConsumption = @MinConsumption, 
                                             Capacity = @Capacity, 
                                             TotalAvailable = @TotalAvailable
                                             WHERE Id = @Id and IsDeleted = 0";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@Id", clubTable.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@CategoryName", clubTable.CategoryName));
                        sqlCommand.Parameters.Add(new SqlParameter("@MinConsumption", clubTable.MinConsumption));
                        sqlCommand.Parameters.Add(new SqlParameter("@Capacity", clubTable.Capacity));
                        sqlCommand.Parameters.Add(new SqlParameter("@TotalAvailable", clubTable.TotalAvailable));
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
