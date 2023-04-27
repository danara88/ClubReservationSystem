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
        /// Inserts a club table in database
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
        /// Deletes a club table by ID
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
                    var query = @"DELETE FROM ClubTables WHERE Id = @Id";
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
        /// Gets all club tables from database
        /// </summary>
        /// <returns></returns>
        public List<ClubTable> GetAll()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"SELECT * FROM ClubTables";
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
        /// Gets a club table by ID
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
                    var query = @"SELECT * FROM ClubTables WHERE Id = @Id";
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
        /// Updates a club table by ID
        /// </summary>
        /// <param name="clubTable"></param>
        /// <returns></returns>
        public bool UpdateById(ClubTable clubTable)
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
                                            WHERE Id = @Id";
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
