//using BusinessLayer.Concrete;
//using DataAccessLayer.EntityFramework;
//using EntityLayer.Concrate;
//using Microsoft.AspNetCore.Mvc;

//namespace Core_Proje.ViewComponents.Contact
//{
//    public class SendMessage : ViewComponent
//    {
//        MessageManager _messageManager = new MessageManager(new EfMessageDal());
//        [HttpGet]
//        public IViewComponentResult Invoke()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IViewComponentResult Invoke(Message message)
//        {
//            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
//            message.Status = true;
//            _messageManager.TAdd(message);
//            return View();
//        }
//    }
//}
