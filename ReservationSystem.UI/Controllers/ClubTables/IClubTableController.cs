namespace ReservationSystem.UI.Controllers;

/// <summary>
/// CLub table controller interface
/// </summary>
public interface IClubTableController
{
    public void DisplayMainMenu();

    public void Create();

    public void Get();

    public void GetAll();

    public void Update();

    public void Delete();
}
