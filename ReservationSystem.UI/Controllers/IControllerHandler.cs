using ReservationSystem.UI.Enums;

namespace ReservationSystem.UI.Controllers
{
    /// <summary>
    /// Controller Handler Interface
    /// </summary>
    public interface IControllerHandler
    {
        public void ExecuteController(AppMainOptionsEnum mainSelectedOption);
    }
}
