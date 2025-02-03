using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrate;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactSubController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            var value = cm.TGetList()[0];
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(Contact p)
        {
            cm.TUpdate(p);
            return View();
        }
    }
}
