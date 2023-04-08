namespace ReservationSystem.UI.Controllers
{
    public class ClubTableController
    {
        /// <summary>
        /// Displays the main menu
        /// </summary>
        public static void DisplayMainMenu()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine(">> Manage club tables");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine("0 - Create club table");
            Console.WriteLine("1 - Get club table");
            Console.WriteLine("2 - Get all club tables");
            Console.WriteLine("3 - Update a club table");
            Console.WriteLine("4 - Delete a club table");
            Console.WriteLine("5 - Go back");
            Console.WriteLine();
        }

        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("Create Club Table");
        }

        public static void Get()
        {
            Console.Clear();
            Console.WriteLine("Get Club Table");
        }

        public static void GetAll()
        {
            Console.Clear();
            Console.WriteLine("GetAll Club Table");
        }

        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("Update Club Table");
        }

        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Delete Club Table");
        }
    }
}
