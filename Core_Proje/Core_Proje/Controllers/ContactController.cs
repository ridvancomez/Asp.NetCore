using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager _messageManager = new(new EfMessageDal());
        public IActionResult Index()
        {
            var messageValues = _messageManager.TGetList();
            return View(messageValues);
        }

        public IActionResult MessageDetail(int id)
        {
            var messageValue = _messageManager.TGetById(id);
            return View(messageValue);
        }

        [HttpGet]
        public IActionResult DeleteMessage(int id)
        {
            var messageValue = _messageManager.TGetById(id);
            _messageManager.TDelete(messageValue);
            return RedirectToAction("Index");
        }
    }
}
