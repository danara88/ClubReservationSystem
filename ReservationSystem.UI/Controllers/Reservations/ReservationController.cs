namespace ReservationSystem.UI.Controllers
{
    public class ReservationController
    {
        /// <summary>
        /// Displays the main menu
        /// </summary>
        public static void DisplayMainMenu()
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

        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("Create Reservation");
        }

        public static void Get()
        {
            Console.Clear();
            Console.WriteLine("Get Reservation");
        }

        public static void GetAll()
        {
            Console.Clear();
            Console.WriteLine("GetAll Reservation");
        }

        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("Update Reservation");
        }

        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Delete Reservation");
        }
    }
}
