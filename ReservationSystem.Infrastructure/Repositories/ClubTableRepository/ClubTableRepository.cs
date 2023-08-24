using Microsoft.Data.SqlClient;
using ReservationSystem.Domain.Entities;
using ReservationSystem.Infrastructure.Data;

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
            var clubTables = new List<ClubTable>() { };
            string query = @"SELECT Id, CategoryName, MinConsumption, Capacity, TotalAvailable 
                                        FROM ClubTables WHERE IsDeleted = 0";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        var clubTable = new ClubTable()
                        {
                            Id = reader.GetInt32(0),
                            CategoryName = reader.GetString(1),
                            MinConsumption = reader.GetDecimal(2),
                            Capacity = reader.GetInt32(3),
                            TotalAvailable = reader.GetInt32(4)
                        };
                        clubTables.Add(clubTable);
                    }

                    reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Something went wrong while connecting to database. {ex.Message}");
                }
            }
            return clubTables;
        }

        /// <summary>
        /// Method to get a club table by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClubTable GetById(int id)
        {
            string query = @"SELECT Id, CategoryName, MinConsumption, Capacity, TotalAvailable 
                                        FROM ClubTables WHERE Id = @Id and IsDeleted = 0";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));

                try
                {
                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Read();

                  
                    var clubTable = new ClubTable()
                    {
                        Id = reader.GetInt32(0),
                        CategoryName = reader.GetString(1),
                        MinConsumption = reader.GetDecimal(2),
                        Capacity = reader.GetInt32(3),
                        TotalAvailable = reader.GetInt32(4)
                    };

                    reader.Close();
                    sqlConnection.Close();

                    return clubTable;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Something went wrong while connecting to database. {ex.Message}");
                }
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
