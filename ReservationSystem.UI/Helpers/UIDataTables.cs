using ConsoleTables;
using ReservationSystem.Domain.Entities;
using ReservationSystem.Domain.DTOs;

namespace ReservationSystem.UI.Helpers
{
    /// <summary>
    /// UI data tables helper
    /// </summary>
    public static class UIDataTables
    {

        /// <summary>
        /// Prints UI table for club tables
        /// </summary>
        /// <param name="clubTables"></param>
        public static void PrintTableForClubTables(List<ClubTable> clubTables)
        {
            if(clubTables.Count() == 0)
            {
                Console.WriteLine(" Not club tables to show ...");
                Console.WriteLine();
                return;
            }
            var table = new ConsoleTable("ID", "Category name", "Min consumption ($)", "Capacity", "Total available");
            foreach (var clubTable in clubTables)
            {
                table.AddRow(clubTable.Id, clubTable.CategoryName, clubTable.MinConsumption, clubTable.Capacity, clubTable.TotalAvailable);
            }
            Console.BackgroundColor= ConsoleColor.DarkBlue;
            table.Write();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Prints UI table for users
        /// </summary>
        /// <param name="clubTables"></param>
        public static void PrintTableForUsers(List<User> users)
        {
            if (users.Count() == 0)
            {
                Console.WriteLine(" Not users to show ...");
                Console.WriteLine();
                return;
            }
            var table = new ConsoleTable("ID", "Complete Name", "Phone number");
            foreach (var user in users)
            {
                table.AddRow(user.Id, user.CompleteName, user.PhoneNumber);
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            table.Write();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Prints UI table for reservations
        /// </summary>
        /// <param name="reservationsDto"></param>
        public static void PrintTableForReservations(List<ReservationDto> reservationsDto)
        {
            if (reservationsDto.Count() == 0)
            {
                Console.WriteLine(" Not reservations to show ...");
                Console.WriteLine();
                return;
            }
            var table = new ConsoleTable("ID", "Admin name", "Admin phone number", "Club table", "Total guests", "Reservation date", "Expiration date");
            foreach (var reservationDto in reservationsDto)
            {
                table.AddRow(reservationDto.Id, reservationDto.AdminName, reservationDto.AdminPhoneNumber, reservationDto.ClubTableName, reservationDto.TotalGuests, reservationDto.ReservationDate, reservationDto.ExpirationDate);
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            table.Write();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
