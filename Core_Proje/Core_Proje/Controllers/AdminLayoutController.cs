using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AdminLayoutController : Controller
    {
        WriterMessageManager writerMessageManager = new(new EfWriterMessageDal());
        public IActionResult ReveiverMessageList ()
        {
            string mail = "rdvncmz3@gmail.com";
            var messageValues = writerMessageManager.TGetListByFilter(x=> x.Receiver == mail);
            return View(messageValues);
        }

        public IActionResult SenderMessageList()
        {
            string mail = "rdvncmz3@gmail.com";
            var messageValues = writerMessageManager.TGetListByFilter(x => x.Sender == mail);
            return View(messageValues);
        }

        public IActionResult MessageDetail(int id)
        {
            var messageValue = writerMessageManager.TGetById(id);
            return View(messageValue);
        }
    }
}
