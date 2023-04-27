using ConsoleTables;
using ReservationSystem.Application.Services;
using ReservationSystem.Domain.Entities;
using ReservationSystem.UI.Helpers;

namespace ReservationSystem.UI.Controllers
{
    public class ClubTableController : IClubTableController
    {
        private readonly IClubTableService _clubTableService;

        public ClubTableController(IClubTableService clubTableService)
        {
            _clubTableService = clubTableService;
        }
        /// <summary>
        /// Displays the main menu
        /// </summary>
        public void DisplayMainMenu()
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

        /// <summary>
        /// Create club table view.
        /// </summary>
        /// <returns></returns>
        public void Create()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Create Club Table");

            Console.Write("Category name: ");
            var categoryName = Console.ReadLine();

            Console.Write("Minimum consumption: ");
            var minConsumption = Console.ReadLine();

            Console.Write("Capacity: ");
            var capacity = Console.ReadLine();

            Console.Write("Total tables available: ");
            var totalAvailable = Console.ReadLine();

            ClubTable clubTable = new ClubTable
            {
                CategoryName = categoryName,
                MinConsumption = decimal.Parse(minConsumption),
                Capacity = int.Parse(capacity),
                TotalAvailable = int.Parse(totalAvailable)
            };

            var result = _clubTableService.CreateClubTable(clubTable);

            if (result)
            {
                UIHelpers.TriggerSuccessMessage(AppConsts.SUCCESS_MESSAGE);
            } else
            {
                UIHelpers.TriggerErrorMessage(AppConsts.FAILURE_MESSAGE);
            }
        }

        /// <summary>
        /// Get club table view.
        /// </summary>
        public void Get()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Get Club Table");

            try
            {
                Console.Write("Category ID: ");
                var id = int.Parse(Console.ReadLine()!);
                var clubTable = _clubTableService.GetClubTable(id);
                if (clubTable is not null)
                {
                    var clubTables = new List<ClubTable>() { clubTable };
                    PrintTable(clubTables);
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
        /// Get club tables view.
        /// </summary>
        public void GetAll()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Get Club Tables");
            var clubTables = _clubTableService.GetClubTables();
            if (clubTables is not null)
            {
                PrintTable(clubTables);
            }
        }

        /// <summary>
        /// Update club table view.
        /// </summary>
        public void Update()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Update Club Table");

            try
            {
                Console.Write("Category ID: ");
                var id = int.Parse(Console.ReadLine()!);
                var clubTable = _clubTableService.GetClubTable(id);
                if (clubTable is not null)
                {

                    Console.Write($"Category name [{clubTable.CategoryName}]: ");
                    var categoryName = Console.ReadLine();

                    Console.Write($"Minimum consumption [{clubTable.MinConsumption}]: ");
                    var minConsumption = Console.ReadLine();

                    Console.Write($"Capacity [{clubTable.Capacity}]: ");
                    var capacity = Console.ReadLine();

                    Console.Write($"Total tables available [{clubTable.TotalAvailable}]: ");
                    var totalAvailable = Console.ReadLine();

                    ClubTable clubTableToUpdate = new ClubTable
                    {
                        Id = clubTable.Id,
                        CategoryName = string.IsNullOrEmpty(categoryName) ? clubTable.CategoryName : categoryName,
                        MinConsumption = string.IsNullOrEmpty(minConsumption) ? clubTable.MinConsumption : decimal.Parse(minConsumption),
                        Capacity = string.IsNullOrEmpty(capacity) ? clubTable.Capacity : int.Parse(capacity),
                        TotalAvailable = string.IsNullOrEmpty(totalAvailable) ? clubTable.TotalAvailable : int.Parse(totalAvailable)
                    };

                    var result = _clubTableService.UpdateClubTable(clubTableToUpdate);

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
            catch(Exception)
            {
                UIHelpers.TriggerErrorMessage(AppConsts.NOT_FOUND_RESOURCE_MESSAGE);
            }
        }

        /// <summary>
        /// Delete club table view.
        /// </summary>
        public void Delete()
        {
            Console.Clear();
            UIHelpers.PrintTitle("Delete Club Table");

            try
            {
                Console.Write("Category ID: ");
                var id = int.Parse(Console.ReadLine()!);
                var clubTable = _clubTableService.GetClubTable(id);
                if (clubTable is not null)
                {
                    var result = _clubTableService.DeleteClubTable(id);
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
        private void PrintTable(List<ClubTable> clubTables)
        {
            var table = new ConsoleTable("ID", "Category name", "Min consumption ($)", "Capacity", "Total available");
            foreach (var clubTable in clubTables)
            {
                table.AddRow(clubTable.Id, clubTable.CategoryName, clubTable.MinConsumption, clubTable.Capacity, clubTable.TotalAvailable);
            }
            table.Write();
            Console.WriteLine();
        }
    }
}
