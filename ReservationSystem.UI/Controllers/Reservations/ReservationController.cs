using ReservationSystem.Application.Services;
using ReservationSystem.Domain.DTOs;
using ReservationSystem.Domain.Entities;
using ReservationSystem.UI.Helpers;

namespace ReservationSystem.UI.Controllers
{
    public class ReservationController : IReservationsController
    {
        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;
        private readonly IClubTableService _clubTableService;


        public ReservationController(IReservationService reservationService, IUserService userService, IClubTableService clubTableService)
        {
            _reservationService = reservationService;
            _userService = userService;
            _clubTableService = clubTableService;
        }

        /// <summary>
        /// Displays the main menu
        /// </summary>
        public void DisplayMainMenu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine(">> Manage reservations menu");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(" 0) - Create reservation");
            Console.WriteLine();
            Console.WriteLine(" 1) - Search reservation");
            Console.WriteLine();
            Console.WriteLine(" 2) - List today reservations");
            Console.WriteLine();
            Console.WriteLine(" 3) - Update a reservation");
            Console.WriteLine();
            Console.WriteLine(" 4) - Delete a reservation");
            Console.WriteLine();
            Console.WriteLine(" 5) - Go back");
            Console.WriteLine();
        }

        /// <summary>
        /// Create reservation view.
        /// </summary>
        /// <returns></returns>
        public void Create()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Create Reservation");

            Console.Write("Search user by name: ");
            var completeName = Console.ReadLine();

            var searchUsers = _userService.GetUsersByCompleteName(completeName);
            UIDataTables.PrintTableForUsers(searchUsers);

            Console.Write("Please insert user ID: ");
            var userId = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please select a club table: ");
            var clubTables = _clubTableService.GetClubTables();
            UIDataTables.PrintTableForClubTables(clubTables);

            Console.Write("Please insert selected club table ID: ");
            var clubTableId = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Today at what hour?[Ex. 22:30]: ");
            var reservationHour = Console.ReadLine();
            Console.WriteLine();
            var hourSplit = reservationHour.Split(':');
            var hour = int.Parse(hourSplit[0]);
            var minute = int.Parse(hourSplit[1]);
            var currentDate = DateTime.Now;
            var reservationDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, hour, minute, 0);

            Console.WriteLine();
            Console.Write("How many people? [Including admin]: ");
            var totalGuests = Console.ReadLine();

            var reservation = new Reservation()
            {
                UserId = int.Parse(userId),
                ClubTableId = int.Parse(clubTableId),
                TotalGuests = int.Parse(totalGuests),
                ReservationDate = reservationDate
            };

            var result = _reservationService.CreateReservation(reservation);

            if (result)
            {
                UIHelpers.TriggerSuccessMessage(AppConsts.SUCCESS_MESSAGE);
            }
            else
            {
                UIHelpers.TriggerErrorMessage(AppConsts.FAILURE_MESSAGE);
            }
            Console.WriteLine();
            DisplayMainMenu();
        }

        /// <summary>
        /// Get reservation view.
        /// </summary>
        public void Get()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Search Reservation");

            try
            {
                Console.Write("Reservation ID: ");
                var id = int.Parse(Console.ReadLine()!);
                var reservationDto = _reservationService.GetReservationDto(id);
                if (reservationDto is not null)
                {
                    var reservationsDto = new List<ReservationDto>() { reservationDto };
                    UIDataTables.PrintTableForReservations(reservationsDto);
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
            Console.WriteLine();
            DisplayMainMenu();
        }

        /// <summary>
        /// Get all reservations view.
        /// </summary>
        public void GetAll()
        {
            Console.Clear();
            UIHelpers.PrintTitle("List All Reservations");
            var reservationsDto = _reservationService.GetReservationsDto();
            if (reservationsDto is not null)
            {
                UIDataTables.PrintTableForReservations(reservationsDto);
            }
            Console.WriteLine();
            DisplayMainMenu();
        }

        /// <summary>
        /// Update reservation view.
        /// </summary>
        public void Update()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Update Reservation");

            try
            {
                Console.Write("Reservation ID: ");
                var id = int.Parse(Console.ReadLine()!);
                var reservation = _reservationService.GetReservationDto(id);
                if (reservation is not null)
                {
                    var userId = reservation.UserId;
                    Console.Write($"Admin [{reservation.AdminName}] [id - {reservation.UserId}] Do you want to change admin ? (y/n): ");
                    var changeAdminName = Console.ReadLine();

                    if (changeAdminName == "y")
                    {
                        // Change reservation user
                        var users = _userService.GetUsers();
                        UIDataTables.PrintTableForUsers(users);

                        Console.Write("Please select a user ID: ");
                        var selectedUserId = int.Parse(Console.ReadLine()!);
                        if(!isValidUser(selectedUserId))
                        {
                            throw new Exception();
                        }
                        userId = selectedUserId;
                    }

                    Console.Write($"Total guests [{reservation.TotalGuests}]: ");
                    var totalGuests = Console.ReadLine();


                    Console.Write($"Reservation hour [{reservation.ReservationDate}] (Ex. 22:30): ");
                    var reservationHour = Console.ReadLine();
                    DateTime reservationDate = new DateTime();
                    if (!string.IsNullOrEmpty(reservationHour))
                    {
                        var hourSplit = reservationHour.Split(':');
                        var hour = int.Parse(hourSplit[0]);
                        var minute = int.Parse(hourSplit[1]);
                        reservationDate = new DateTime(reservation.ReservationDate.Year, reservation.ReservationDate.Month, reservation.ReservationDate.Day, hour, minute, 0);
                    }

                    Reservation reservationToUpdate = new Reservation
                    {
                        Id = reservation.Id,
                        UserId = userId,
                        ClubTableId = reservation.ClubTableId,
                        TotalGuests = string.IsNullOrEmpty(totalGuests) ? reservation.TotalGuests : int.Parse(totalGuests),
                        ReservationDate = string.IsNullOrEmpty(reservationHour) ? reservation.ReservationDate : reservationDate,
                        ExpirationDate = string.IsNullOrEmpty(reservationHour) ? reservation.ExpirationDate : reservationDate.AddHours(1)
                    };

                    var result = _reservationService.UpdateReservation(reservationToUpdate);

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
            Console.WriteLine();
            DisplayMainMenu();
        }

        /// <summary>
        /// Delete reservation view.
        /// </summary>
        public void Delete()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Delete Reservation");

            try
            {
                Console.Write("Reservation ID: ");
                var id = int.Parse(Console.ReadLine()!);
                var reservation = _reservationService.GetReservationDto(id);
                if (reservation is not null)
                {
                    var result = _reservationService.DeleteReservation(id);
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
            Console.WriteLine();
            DisplayMainMenu();
        }

        /// <summary>
        /// Validate if user exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool isValidUser(int id)
        {
            var result = _userService.GetUser(id);
            return result is null ? false : true;
        }
    }
}
