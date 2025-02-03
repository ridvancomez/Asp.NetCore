using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [Authorize]
    public class DefaultController : Controller
    {
        AnnouncementManger announcementManger = new(new EfAnnouncementDal());
        public IActionResult Index()
        {
            var values = announcementManger.TGetList();
            return View(values);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var value = announcementManger.TGetById(id);
            announcementManger.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var value = announcementManger.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement value)
        {
            announcementManger.TUpdate(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement value)
        {
            announcementManger.TAdd (value);  
            return RedirectToAction("Index");
        }
    }
}
