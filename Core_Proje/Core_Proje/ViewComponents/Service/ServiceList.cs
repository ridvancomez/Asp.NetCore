using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Core_Proje.ViewComponents.Service
{
    public class ServiceList :  ViewComponent
    {
        ServiceManager serviceList = new ServiceManager(new EfServiceDal());
        public IViewComponentResult Invoke()
        {
            var values = serviceList.TGetList();
            return View(values);
        }
    }
}
