using ReservationSystem.UI.Enums;

namespace ReservationSystem.UI.Helpers
{
    public static class UIHelpers
    {
        /// <summary>
        /// Gets the main selected option of the system.
        /// </summary>
        /// <returns>AppMainOptionsEnum</returns>
        public static AppMainOptionsEnum GetSelectedOption()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select an option: ");
            Console.ForegroundColor = ConsoleColor.Gray;

            var selectedOption = Console.ReadLine();

            if (string.IsNullOrEmpty(selectedOption))
            {
                return AppMainOptionsEnum.ErrorNullEmpty;
            }

            try
            {
                return (AppMainOptionsEnum)int.Parse(selectedOption);
            }
            catch (FormatException)
            {
                return AppMainOptionsEnum.ErrorFormat;
            }
        }

        /// <summary>
        /// Gets the selected action
        /// </summary>
        /// <returns>AppActionsEnum</returns>
        public static AppActionsEnum GetSelectedAction()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select an option: ");
            Console.ForegroundColor = ConsoleColor.Gray;

            var selectedAction = Console.ReadLine();

            if(string.IsNullOrEmpty(selectedAction))
            {
                return AppActionsEnum.ErrorFormat;  
            }

            try
            {
                return (AppActionsEnum)int.Parse(selectedAction);
            }
            catch (FormatException)
            {
                return AppActionsEnum.ErrorNullEmpty;
            }
        }

        /// <summary>
        /// Displays error message in UI
        /// </summary>
        /// <param name="message"></param>
        /// <returns>void</returns>
        public static void TriggerErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {message}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Displays success message in UI
        /// </summary>
        /// <param name="message"></param>
        public static void TriggerSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS: {message}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Prints the main menu
        /// </summary>
        public static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("> Club Reservation System");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Available options: ");
            Console.WriteLine();
            Console.WriteLine("0 - Manage reservations");
            Console.WriteLine("1 - Manage club tables");
            Console.WriteLine("2 - Manage users");
            Console.WriteLine("3 - Exit program");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints UI title
        /// </summary>
        /// <param name="title"></param>
        public static void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("----------------------------");
            Console.WriteLine($">>> {title}");
            Console.WriteLine("----------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
