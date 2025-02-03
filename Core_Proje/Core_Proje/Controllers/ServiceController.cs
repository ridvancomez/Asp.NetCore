using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new(new EfServiceDal());
        public IActionResult Index()
        {
            BreadCrumb("Hizmetler", "Hizmetler");
            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            BreadCrumb("Hizmet Ekle", "Hizmetler");
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(int id)
        {
            var serviceValue = serviceManager.TGetById(id);
            serviceManager.TDelete(serviceValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            BreadCrumb("Hizmet Ekle", "Hizmetler");
            var serviceValue = serviceManager.TGetById(id);
            return View(serviceValue);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            BreadCrumb("Hizmet Ekle", "Hizmetler");
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }

        private void BreadCrumb(string breadCrumb, string breadCrumbBase)
        {
            ViewBag.Breadcrumb = breadCrumb;
            ViewBag.BreadcrumbBase = breadCrumbBase;
            ViewBag.Link = "/Service/Index";
        }
    }
}
