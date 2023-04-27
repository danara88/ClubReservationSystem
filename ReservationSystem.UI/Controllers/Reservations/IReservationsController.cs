namespace ReservationSystem.UI.Controllers;

/// <summary>
/// Reservations controller interface
/// </summary>
public interface IReservationsController
{
    public void DisplayMainMenu();

    public void Create();

    public void Get();

    public void GetAll();

    public void Update();

    public void Delete();
}
