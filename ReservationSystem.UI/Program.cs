using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReservationSystem.Application.Services;
using ReservationSystem.Infrastructure.Repositories;
using ReservationSystem.UI.Controllers;
using ReservationSystem.UI.Helpers;

/**
 * Configures the inversion control container.
 */
var hostBuilder = Host.CreateDefaultBuilder(args);
hostBuilder = hostBuilder.ConfigureServices(ServiceConfiguration);
using var host = hostBuilder.Build();

Main();

/**
 * Starts program execution.
 * SystemPrompt is the main APP input.
 */
void Main()
{
    var controllerHandler = host.Services.GetRequiredService<IControllerHandler>();
    int systemPrompt = 0;

    while (systemPrompt == 0)
    {
        Console.Clear();
        UIHelpers.PrintMenu();
        var selectedOption = UIHelpers.GetSelectedOption();
        controllerHandler.ExecuteController(selectedOption);
    }
}

/**
 * Configure all app services.
 */
void ServiceConfiguration(IServiceCollection services)
{
    // Add your services here...

    // Controllers
    services.AddTransient<IControllerHandler, ControllerHandler>();
    services.AddTransient<IActionHandler, ActionHandler>();
    services.AddTransient<IClubTableController, ClubTableController>();
    services.AddTransient<IReservationsController, ReservationController>();
    services.AddTransient<IUsersController, UserController>();

    // Repositories
    services.AddTransient<IClubTableRepository, ClubTableRepository>();
    services.AddTransient<IUserRepository, UserRepository>();

    // Services
    services.AddTransient<IClubTableService, ClubTableService>();
    services.AddTransient<IUserService, UserService>();
}