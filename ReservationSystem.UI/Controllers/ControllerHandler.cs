using ReservationSystem.UI.Enums;
using ReservationSystem.UI.Helpers;

namespace ReservationSystem.UI.Controllers
{
    public class ControllerHandler
    {
        /// <summary>
        /// Handles the app controllers
        /// </summary>
        /// <param name="mainSelectedOption"></param>
        public static void ExecuteController(AppMainOptionsEnum mainSelectedOption)
        {
            if (mainSelectedOption is AppMainOptionsEnum.ErrorNullEmpty || mainSelectedOption is AppMainOptionsEnum.ErrorFormat)
            {
                UIHelpers.TriggerErrorMessage($"Sorry, the command {(int)mainSelectedOption} is not valid.");
                return;
            }
            Type controllerType;
            switch (mainSelectedOption)
            {
                case AppMainOptionsEnum.ManageReservations:
                    Console.Clear();
                    ReservationController.DisplayMainMenu();
                    controllerType = typeof(ReservationController);
                    ActionHandler.ExecuteSubActionLoop(controllerType);
                    break;
                case AppMainOptionsEnum.ManageClubTables:
                    Console.Clear();
                    ClubTableController.DisplayMainMenu();
                    controllerType = typeof(ClubTableController);
                    ActionHandler.ExecuteSubActionLoop(controllerType);
                    break;
                case AppMainOptionsEnum.ManageUsers:
                    Console.Clear();
                    UserController.DisplayMainMenu();
                    controllerType = typeof(UserController);
                    ActionHandler.ExecuteSubActionLoop(controllerType);
                    break;
                case AppMainOptionsEnum.ExitProgram:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                case AppMainOptionsEnum.ErrorFormat:
                    Console.Clear();
                    UIHelpers.TriggerErrorMessage("Format error. Please select a valid option.");
                    break;
                case AppMainOptionsEnum.ErrorNullEmpty:
                    Console.Clear();
                    UIHelpers.TriggerErrorMessage("Empty option. Please select a valid option.");
                    break;
                default:
                    Console.Clear();
                    UIHelpers.TriggerErrorMessage($"Sorry, the command {(int)mainSelectedOption} is not valid.");
                    break;
            }
        }
    }
}
