using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]")]
    public class MessageController : Controller
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]
        [Route("Index")]

        public async Task<IActionResult> Index(string p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var _mailList = _writerMessageManager.TGetListByFilter(x => x.Receiver == user.Email);
            return View(_mailList);
        }
        [Route("MessageDetail/{id}")]
        public IActionResult MessageDetail(int id)
        {
            var messageValue = _writerMessageManager.TGetById(id);
            return View(messageValue);
        }

        [HttpPost]
        [Route("GetMessages")]
        public async Task<IActionResult> GetMessages([FromForm] string messageType)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            List<WriterMessage> writerMailList = new();
            switch (messageType)
            {
                case "Receiver":
                    writerMailList = _writerMessageManager.TGetListByFilter(x => x.Receiver == user.Email);
                    break;
                case "Sender":
                    writerMailList = _writerMessageManager.TGetListByFilter(x => x.Sender == user.Email);
                    break;
            }

            return Json(writerMailList); // JSON formatında veriyi döneriz
        }

        [HttpGet]
        [Route("AddMessage")]
        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("AddMessage")]
        public async Task<IActionResult> AddMessage(WriterMessage newMessage)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            newMessage.Sender = user.Email;
            newMessage.SenderName = user.Name;
            _writerMessageManager.TAdd(newMessage);
            return RedirectToAction("Index");

        }
    }
}
