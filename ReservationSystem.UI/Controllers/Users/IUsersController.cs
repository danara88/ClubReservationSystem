namespace ReservationSystem.UI.Controllers;

/// <summary>
/// Users controller interface
/// </summary>
public interface IUsersController
{
    public void DisplayMainMenu();

    public void Create();

    public void Get();

    public void GetAll();

    public void Update();

    public void Delete();
}
