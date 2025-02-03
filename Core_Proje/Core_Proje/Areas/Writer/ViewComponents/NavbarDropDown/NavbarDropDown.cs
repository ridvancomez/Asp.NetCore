using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents.NavbarDropDown
{
    public class NavbarDropDown : ViewComponent
    {
        AnnouncementManger _announcementManger = new AnnouncementManger(new EfAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var values = _announcementManger.TGetList();
            return View(values);
        }
    }
}
