using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new(new EfAboutDal());

        [HttpGet]
        public IActionResult Index()
        {
            BreadCrumb("Hakkımda", "Hakkımda");
            var value = aboutManager.TGetList()[0];
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            BreadCrumb("Hakkımda", "Hakkımda");
            aboutManager.TUpdate(about);
            return View();
        }

        private void BreadCrumb(string breadCrumb, string breadCrumbBase)
        {
            ViewBag.Breadcrumb = breadCrumb;
            ViewBag.BreadcrumbBase = breadCrumbBase;
            ViewBag.Link = "/About/Index";
        }
    }
}
