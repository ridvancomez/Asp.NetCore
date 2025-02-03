using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.NatificationNavbar
{
    public class NotificationNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
