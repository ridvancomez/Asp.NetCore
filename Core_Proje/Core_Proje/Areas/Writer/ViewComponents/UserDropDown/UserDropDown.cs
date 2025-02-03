using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents.UserDropDown
{
    public class UserDropDown : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public UserDropDown(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Image = user?.ImageUrl;
            return View();
        }
    }
}
