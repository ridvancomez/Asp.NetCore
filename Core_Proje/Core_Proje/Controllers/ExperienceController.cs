using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        readonly ExperienceManager experienceManager = new (new EfExperienceDal());
        public IActionResult Index()
        {
            BreadCrumb("Deneyimler", "Deneyimler");
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            BreadCrumb("Deneyim Ekle", "Deneyimler");
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteExperience(int id)
        {
            var value = experienceManager.TGetById(id);
            experienceManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            BreadCrumb("Deneyim Güncelle", "Deneyimler");
            var value = experienceManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }

        private void BreadCrumb(string breadCrumb, string breadCrumbBase)
        {
            ViewBag.Breadcrumb = breadCrumb;
            ViewBag.BreadcrumbBase = breadCrumbBase;
            ViewBag.Link = "/Experience/Index";
        }
    }
}
