using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatictistics : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.Skills = c.Skills.Count();
            ViewBag.DontReadMessages = c.Messages.Where(x => x.Status == false).Count();
            ViewBag.ReadMessages = c.Messages.Where(x => x.Status == true).Count();
            ViewBag.Experience = c.Experience.Count();
            return View();
        }
    }
}
