 using ReservationSystem.UI.Enums;
using ReservationSystem.UI.Helpers;
using System.Reflection;

namespace ReservationSystem.UI.Controllers
{
    public class ActionHandler
    {
        /// <summary>
        /// Executes the correct action selected
        /// </summary>
        /// <param name="appControllerType"></param>
        /// <param name="appActionsEnum"></param>
        public static void ExecuteAction(Type appControllerType, AppActionsEnum appActionsEnum, out int promptOut)
        {
            promptOut = 0;
            object instance = Activator.CreateInstance(appControllerType)!;
            switch (appActionsEnum)
            {
                case AppActionsEnum.Create:
                    appControllerType.InvokeMember(Enum.GetName(typeof(AppActionsEnum), (int)AppActionsEnum.Create)!,
                        BindingFlags.InvokeMethod, binder: null, target: instance, args: new object[] { });
                    break;
                case AppActionsEnum.Get:
                    appControllerType.InvokeMember(Enum.GetName(typeof(AppActionsEnum), (int)AppActionsEnum.Get)!,
                       BindingFlags.InvokeMethod, binder: null, target: instance, args: new object[] { });
                    break;
                case AppActionsEnum.GetAll:
                    appControllerType.InvokeMember(Enum.GetName(typeof(AppActionsEnum), (int)AppActionsEnum.GetAll)!,
                       BindingFlags.InvokeMethod, binder: null, target: instance, args: new object[] { });
                    break;
                case AppActionsEnum.Update:
                    appControllerType.InvokeMember(Enum.GetName(typeof(AppActionsEnum), (int)AppActionsEnum.Update)!,
                        BindingFlags.InvokeMethod, binder: null, target: instance, args: new object[] { });
                    break;
                case AppActionsEnum.Delete:
                    appControllerType.InvokeMember(Enum.GetName(typeof(AppActionsEnum), (int)AppActionsEnum.Delete)!,
                         BindingFlags.InvokeMethod, binder: null, target: instance, args: new object[] { });
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
        /// Executes the sub system actions
        /// </summary>
        /// <param name="controllerType"></param>
        public static void ExecuteSubActionLoop(Type controllerType)
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
    }
}
