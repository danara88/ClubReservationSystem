namespace ReservationSystem.UI.Controllers
{
    public class UserController
    {
        /// <summary>
        /// Displays the main menu
        /// </summary>
        public static void DisplayMainMenu()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine(">> Manage users");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine("0 - Register a user");
            Console.WriteLine("1 - Get user");
            Console.WriteLine("2 - Get all users");
            Console.WriteLine("3 - Update a user");
            Console.WriteLine("4 - Delete a user");
            Console.WriteLine("5 - Go back");
            Console.WriteLine();
        }
        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("Create User");
        }

        public static void Get()
        {
            Console.Clear();
            Console.WriteLine("Get User");
        }

        public static void GetAll()
        {
            Console.Clear();
            Console.WriteLine("GetAll User");
        }

        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("Update User");
        }

        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Delete User");
        }
    }
}
