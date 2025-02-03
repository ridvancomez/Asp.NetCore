using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NameSurname = values.Name + " " + values.Surname;

            //User Image
            ViewBag.Image = values.ImageUrl;

            //Weather API
            ViewBag.Weather = await GetWeather();



            //Statistics
            Context c = new Context();
            ViewBag.V1 = c.WriterMessages.Where(x => x.Receiver == values.Email).ToList().Count;
            ViewBag.V2 = c.Announcements.Count();
            ViewBag.V3 = c.Users.Count();
            ViewBag.V4 = c.Skills.Count();
            return View();
        }


        private async Task<string> GetWeather()
        {
            try
            {
                string api = "b9d99e774719a8c8e43b7f2064afbd5b";
                string city = "istanbul";
                string connection = $"https://api.openweathermap.org/data/2.5/weather?q={city}&mode=xml&units=metric&lang=tr&appid={api}";
                using var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync(connection);

                XDocument document = XDocument.Load(connection);

                return document.Descendants("temperature").FirstOrDefault().Attribute("value").Value;
            }
            catch (Exception ex)
            {
                return ex.Message + " hata";
            }
        }
    }
}