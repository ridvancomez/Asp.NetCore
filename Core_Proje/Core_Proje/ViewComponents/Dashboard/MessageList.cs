using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

using DataAccessLayer.EntityFramework;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
