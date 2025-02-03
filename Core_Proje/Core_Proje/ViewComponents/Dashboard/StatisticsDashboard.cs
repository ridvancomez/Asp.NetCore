using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class StatisticsDashboard : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.V1 = c.Portfolios.Count();
            ViewBag.V2 = c.Skills.Count();
            ViewBag.V3 = c.Service.Count();
            return View();
        }
    }
}
