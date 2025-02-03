using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager _socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            var values = _socialMediaManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(EntityLayer.Concrate.SocialMedia p)
        {
            _socialMediaManager.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _socialMediaManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(EntityLayer.Concrate.SocialMedia p)
        {
            _socialMediaManager.TUpdate(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaManager.TGetById(id);
            _socialMediaManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
