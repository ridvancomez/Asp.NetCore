using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        [HttpGet]
        public IActionResult Index()
        {
            BreadCrumb("Öne Çıkanlar", "Öne Çıkanlar");
            var value = featureManager.TGetList()[0];
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            featureManager.TUpdate(feature);
            return RedirectToAction("Index");
        }

        private void BreadCrumb(string breadCrumb, string breadCrumbBase)
        {
            ViewBag.Breadcrumb = breadCrumb;
            ViewBag.BreadcrumbBase = breadCrumbBase;
            ViewBag.Link = "/Feature/Index";
        }
    }
}
