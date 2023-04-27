using ReservationSystem.UI.Enums;
using ReservationSystem.UI.Helpers;

namespace ReservationSystem.UI.Controllers
{
    /// <summary>
    /// This is the action handler.
    /// Responsible of handling controller actions.
    /// </summary>
    public class ActionHandler : IActionHandler
    {
        private readonly IClubTableController _clubTableController;
        private readonly IReservationsController _reservationsController;
        private readonly IUsersController _usersController;

        public ActionHandler(IClubTableController clubTableController, IReservationsController reservationsController, IUsersController usersController)
        {
            _clubTableController = clubTableController;
            _reservationsController = reservationsController;
            _usersController = usersController;
        }

        /// <summary>
        /// Executes the sub system actions
        /// </summary>
        /// <param name="controllerType"></param>
        public void ExecuteSubActionLoop(Type controllerType)
        {
            int promptSubSystem = 0;
            while (promptSubSystem == 0)
            {
                AppActionsEnum optionSelected = UIHelpers.GetSelectedAction();
                int promptOut;
                ExecuteAction(controllerType, optionSelected, out promptOut);
                promptSubSystem = promptOut;
            }
        }

        /// <summary>
        /// Executes the correct action selected
        /// </summary>
        /// <param name="appControllerType"></param>
        /// <param name="appActionsEnum"></param>
        private void ExecuteAction(Type appControllerType, AppActionsEnum appActionsEnum, out int promptOut)
        {
            promptOut = 0;
            switch (appActionsEnum)
            {
                case AppActionsEnum.Create:
                    ExecuteActionByController(appControllerType, AppActionsEnum.Create);
                    break;
                case AppActionsEnum.Get:
                    ExecuteActionByController(appControllerType, AppActionsEnum.Get);
                    break;
                case AppActionsEnum.GetAll:
                    ExecuteActionByController(appControllerType, AppActionsEnum.GetAll);
                    break;
                case AppActionsEnum.Update:
                    ExecuteActionByController(appControllerType, AppActionsEnum.Update);
                    break;
                case AppActionsEnum.Delete:
                    ExecuteActionByController(appControllerType, AppActionsEnum.Delete);
                    break;
                case AppActionsEnum.Exit:
                    promptOut = 1;
                    break;
                case AppActionsEnum.ErrorFormat:
                    UIHelpers.TriggerErrorMessage("Format error. Please select a valid option.");
                    break;
                case AppActionsEnum.ErrorNullEmpty:
                    UIHelpers.TriggerErrorMessage("Empty option. Please select a valid option.");
                    break;
                default:
                    UIHelpers.TriggerErrorMessage("Action not found");
                    break;
            }
        }

        /// <summary>
        /// Executes actions by controller type
        /// </summary>
        /// <param name="controllerType"></param>
        /// <param name="appActionEnum"></param>
        private void ExecuteActionByController(Type controllerType, AppActionsEnum appActionEnum)
        {
            if (controllerType == typeof(ClubTableController))
            {
                switch (appActionEnum)
                {
                    case AppActionsEnum.Create:
                        _clubTableController.Create();
                        break;
                    case AppActionsEnum.Get:
                        _clubTableController.Get();
                        break;
                    case AppActionsEnum.GetAll:
                        _clubTableController.GetAll();
                        break;
                    case AppActionsEnum.Update:
                        _clubTableController.Update();
                        break;
                    case AppActionsEnum.Delete:
                        _clubTableController.Delete();
                        break;
                }
            }
            if (controllerType == typeof(ReservationController))
            {
                switch (appActionEnum)
                {
                    case AppActionsEnum.Create:
                        _reservationsController.Create();
                        break;
                    case AppActionsEnum.Get:
                        _reservationsController.Get();
                        break;
                    case AppActionsEnum.GetAll:
                        _reservationsController.GetAll();
                        break;
                    case AppActionsEnum.Update:
                        _reservationsController.Update();
                        break;
                    case AppActionsEnum.Delete:
                        _reservationsController.Delete();
                        break;
                }
            }
            if (controllerType == typeof(UserController))
            {
                switch (appActionEnum)
                {
                    case AppActionsEnum.Create:
                        _usersController.Create();
                        break;
                    case AppActionsEnum.Get:
                        _usersController.Get();
                        break;
                    case AppActionsEnum.GetAll:
                        _usersController.GetAll();
                        break;
                    case AppActionsEnum.Update:
                        _usersController.Update();
                        break;
                    case AppActionsEnum.Delete:
                        _usersController.Delete();
                        break;
                }
            }
        }
    }
}
