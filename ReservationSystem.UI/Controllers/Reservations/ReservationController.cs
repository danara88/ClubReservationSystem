using ReservationSystem.UI.Controllers;

namespace ReservationSystem.UI.Controllers
{
    public class ReservationController : IReservationsController
    {
        /// <summary>
        /// Displays the main menu
        /// </summary>
        public void DisplayMainMenu()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine(">> Manage reservations");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine("0 - Create reservation");
            Console.WriteLine("1 - Get reservation");
            Console.WriteLine("2 - Get all reservations");
            Console.WriteLine("3 - Update a reservation");
            Console.WriteLine("4 - Delete a reservation");
            Console.WriteLine("5 - Go back");
            Console.WriteLine();
        }

        public void Create()
        {
            Console.Clear();
            Console.WriteLine("Create Reservation");
        }

        public void Get()
        {
            Console.Clear();
            Console.WriteLine("Get Reservation");
        }

        public void GetAll()
        {
            Console.Clear();
            Console.WriteLine("GetAll Reservation");
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Update Reservation");
        }

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("Delete Reservation");
        }
    }
}
