using ReservationSystem.UI.Controllers;
using ReservationSystem.UI.Helpers;

/*
 * Start program execution.
 * 
 */
int systemPrompt = 0;

while (systemPrompt == 0)
{
    Console.Clear();
    UIHelpers.PrintMenu();
    var selectedOption = UIHelpers.GetSelectedOption();
    ControllerHandler.ExecuteController(selectedOption);
}