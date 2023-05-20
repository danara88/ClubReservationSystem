using ReservationSystem.UI.Enums;
using ReservationSystem.UI.Helpers;

namespace ReservationSystem.UI.Controllers
{
    /// <summary>
    /// This is the controller handler.
    /// Responsable of handling app controllers.
    /// </summary>
    public class ControllerHandler : IControllerHandler
    {
        private readonly IActionHandler _actionHandler;
        private readonly IClubTableController _clubTableController;
        private readonly IReservationsController _reservationController;
        private readonly IUsersController _usersController;

        public ControllerHandler(
            IActionHandler actionHandler, 
            IClubTableController clubTableController, 
            IReservationsController reservationController, 
            IUsersController usersController)
        {
            _actionHandler = actionHandler;
            _clubTableController = clubTableController;
            _reservationController = reservationController;
            _usersController = usersController;
        }

        /// <summary>
        /// Handles app's controllers
        /// </summary>
        /// <param name="mainSelectedOption"></param>
        public void ExecuteController(AppMainOptionsEnum mainSelectedOption)
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
                    _reservationController.DisplayMainMenu();
                    controllerType = typeof(ReservationController);
                    _actionHandler.ExecuteSubActionLoop(controllerType);
                    break;
                case AppMainOptionsEnum.ManageClubTables:
                    Console.Clear();
                    _clubTableController.DisplayMainMenu();
                    controllerType = typeof(ClubTableController);
                    _actionHandler.ExecuteSubActionLoop(controllerType);
                    break;
                case AppMainOptionsEnum.ManageUsers:
                    Console.Clear();
                    _usersController.DisplayMainMenu();
                    controllerType = typeof(UserController);
                    _actionHandler.ExecuteSubActionLoop(controllerType);
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
