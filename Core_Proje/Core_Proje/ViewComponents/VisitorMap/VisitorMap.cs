using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.VisitorMap
{
    public class VisitorMap : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
