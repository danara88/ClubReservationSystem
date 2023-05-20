using Microsoft.Data.SqlClient;
using ReservationSystem.Domain.Entities;
using ReservationSystem.Infrastructure.Data;
using System.Data;

namespace ReservationSystem.Infrastructure.Repositories
{
    /// <summary>
    /// Reservation repository
    /// </summary>
    public class ReservationRepository : IReservationRepository
    {

        private readonly string _connectionString = ConnectionSettings.CONNECTION_STRING;

        public ReservationRepository()
        {
        }

        /// <summary>
        /// Method to create a reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool Create(Reservation reservation)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"INSERT INTO Reservations(UserId, ClubTableId, TotalGuests, ReservationDate, ExpirationDate)
		                                      VALUES(@UserId, @ClubTableId, @TotalGuests, @ReservationDate, @ExpirationDate)";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@UserId", reservation.UserId));
                        sqlCommand.Parameters.Add(new SqlParameter("@ClubTableId", reservation.ClubTableId));
                        sqlCommand.Parameters.Add(new SqlParameter("@TotalGuests", reservation.TotalGuests));
                        sqlCommand.Parameters.Add(new SqlParameter("@ReservationDate", reservation.ReservationDate));
                        sqlCommand.Parameters.Add(new SqlParameter("@ExpirationDate", reservation.ExpirationDate));

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
        /// Method to delete a reservation
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
                    var query = @"UPDATE Reservations SET IsDeleted = 1 WHERE Id = @Id and IsDeleted = 0";
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
        /// Method to get all reservations
        /// </summary>
        /// <returns></returns>
        public List<Reservation> GetAll()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"SELECT * FROM Reservations WHERE IsDeleted = 0";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            var dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);

                            var reservations = new List<Reservation>() { };

                            foreach (DataRow row in dataTable.Rows)
                            {
                                reservations.Add(new Reservation
                                {
                                    Id = (int)row["Id"],
                                    UserId = (int)row["UserId"],
                                    ClubTableId = (int)row["ClubTableId"],
                                    TotalGuests = (int)row["TotalGuests"],
                                    ReservationDate = DateTime.Parse(row["ReservationDate"].ToString()!),
                                    ExpirationDate = DateTime.Parse(row["ExpirationDate"].ToString()!),
                                });
                            }
                            return reservations;
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
        /// Method to get a reservationby ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Reservation GetById(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"SELECT * FROM Reservations WHERE Id = @Id and IsDeleted = 0";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            var dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);

                            var reservations = new List<Reservation>() { };

                            foreach (DataRow row in dataTable.Rows)
                            {
                                reservations.Add(new Reservation
                                {
                                    Id = (int)row["Id"],
                                    UserId = (int)row["UserId"],
                                    ClubTableId = (int)row["ClubTableId"],
                                    TotalGuests = (int)row["TotalGuests"],
                                    ReservationDate = DateTime.Parse(row["ReservationDate"].ToString()!),
                                    ExpirationDate = DateTime.Parse(row["ExpirationDate"].ToString()!),
                                });
                            }
                            return reservations[0];
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
        /// Method to update a reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool Update(Reservation reservation)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var query = @"UPDATE Reservations
                                         SET UserId = @UserId, 
                                             ClubTableId = @ClubTableId,
                                             TotalGuests = @TotalGuests,
                                             ReservationDate = @ReservationDate,
                                             ExpirationDate = @ExpirationDate
                                             WHERE Id = @Id and IsDeleted = 0";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@Id", reservation.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@UserId", reservation.UserId));
                        sqlCommand.Parameters.Add(new SqlParameter("@ClubTableId", reservation.ClubTableId));
                        sqlCommand.Parameters.Add(new SqlParameter("@TotalGuests", reservation.TotalGuests));
                        sqlCommand.Parameters.Add(new SqlParameter("@ReservationDate", reservation.ReservationDate));
                        sqlCommand.Parameters.Add(new SqlParameter("@ExpirationDate", reservation.ExpirationDate));
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
