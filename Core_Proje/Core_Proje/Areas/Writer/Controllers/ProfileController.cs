using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new UserEditViewModel();
            model.Name = user.Name;
            model.Surname = user.Surname;
            model.PictureUrl = user.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel user)
        {
            if (user.Password == user.ConfirmPassword)
            {
                var _user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user.Picture != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(user.Picture.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = resource + "/wwwroot/UserImage/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await user.Picture.CopyToAsync(stream);
                    _user.ImageUrl = imageName;
                }

                _user.Name = user.Name;
                _user.Surname = user.Surname;

                if (user.Password == user.ConfirmPassword && (user.Password != null && user.Password != ""))
                    _user.PasswordHash = _userManager.PasswordHasher.HashPassword(_user, user.Password);

                var result = await _userManager.UpdateAsync(_user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Logout", "Login");
                }
            }
            return View();
        }
    }
}
