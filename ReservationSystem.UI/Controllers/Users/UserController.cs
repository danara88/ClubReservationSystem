using ConsoleTables;
using ReservationSystem.Application.Services;
using ReservationSystem.Domain.Entities;
using ReservationSystem.UI.Helpers;

namespace ReservationSystem.UI.Controllers
{
    public class UserController : IUsersController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Displays the main menu
        /// </summary>
        public void DisplayMainMenu()
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

        /// <summary>
        /// Create user view.
        /// </summary>
        public void Create()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Create User");

            Console.Write("User complete name: ");
            var completeName = Console.ReadLine();

            Console.Write("Phone number: ");
            var phoneNumber = Console.ReadLine();

            User user = new User
            {
                CompleteName = completeName,
                PhoneNumber = phoneNumber
            };

            var result = _userService.CreateUser(user);

            if (result)
            {
                UIHelpers.TriggerSuccessMessage(AppConsts.SUCCESS_MESSAGE);
            }
            else
            {
                UIHelpers.TriggerErrorMessage(AppConsts.FAILURE_MESSAGE);
            }
        }

        /// <summary>
        /// Get user view.
        /// </summary>
        public void Get()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Get User");

            try
            {
                Console.Write("User ID: ");
                var id = int.Parse(Console.ReadLine()!);
                var user = _userService.GetUser(id);
                if (user is not null)
                {
                    var users = new List<User>() { user };
                    PrintTable(users);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                UIHelpers.TriggerErrorMessage(AppConsts.INVALID_FORMAT_MESSAGE);
            }
        }

        /// <summary>
        /// Get users view.
        /// </summary>
        public void GetAll()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Get Users");
            var users = _userService.GetUsers();
            if (users is not null)
            {
                PrintTable(users);
            }
        }

        /// <summary>
        /// Update user view.
        /// </summary>
        public void Update()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Update User");

            try
            {
                Console.Write("User ID: ");
                var id = int.Parse(Console.ReadLine()!);
                var user = _userService.GetUser(id);
                if (user is not null)
                {

                    Console.Write($"Complete name [{user.CompleteName}]: ");
                    var completeName = Console.ReadLine();

                    Console.Write($"Phone number [{user.PhoneNumber}]: ");
                    var phoneNumber = Console.ReadLine();

                    User userToUpdate = new User
                    {
                        Id = user.Id,
                        CompleteName = string.IsNullOrEmpty(completeName) ? user.CompleteName : completeName,
                        PhoneNumber = string.IsNullOrEmpty(phoneNumber) ? user.PhoneNumber : phoneNumber,
                    };

                    var result = _userService.UpdateUser(userToUpdate);

                    if (result)
                    {
                        UIHelpers.TriggerSuccessMessage(AppConsts.SUCCESS_MESSAGE);
                    }
                    else
                    {
                        UIHelpers.TriggerErrorMessage(AppConsts.FAILURE_MESSAGE);
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (FormatException)
            {
                UIHelpers.TriggerErrorMessage(AppConsts.INVALID_FORMAT_MESSAGE);
            }
            catch (Exception)
            {
                UIHelpers.TriggerErrorMessage(AppConsts.NOT_FOUND_RESOURCE_MESSAGE);
            }
        }

        /// <summary>
        /// Delete user view.
        /// </summary>
        public void Delete()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Delete User");

            try
            {
                Console.Write("User ID: ");
                var id = int.Parse(Console.ReadLine()!);
                var user = _userService.GetUser(id);
                if (user is not null)
                {
                    var result = _userService.DeleteUser(id);
                    if (result)
                    {
                        UIHelpers.TriggerSuccessMessage(AppConsts.SUCCESS_MESSAGE);
                    }
                    else
                    {
                        UIHelpers.TriggerErrorMessage(AppConsts.FAILURE_MESSAGE);
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                UIHelpers.TriggerErrorMessage(AppConsts.INVALID_FORMAT_MESSAGE);
            }
        }

        /// <summary>
        /// Prints UI table
        /// </summary>
        /// <param name="clubTables"></param>
        private void PrintTable(List<User> users)
        {
            var table = new ConsoleTable("ID", "Complete Name", "Phone number");
            foreach (var user in users)
            {
                table.AddRow(user.Id, user.CompleteName, user.PhoneNumber);
            }
            table.Write();
            Console.WriteLine();
        }
    }
}
