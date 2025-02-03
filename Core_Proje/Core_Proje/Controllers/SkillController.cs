using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.Breadcrumb = "Yetenekler";
            ViewBag.BreadcrumbBase = "Yetenekler";
            ViewBag.Link = "/Skill/Index";
            var values = skillManager.TGetList();
            
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.Breadcrumb = "Yetenek Ekle";
            ViewBag.BreadcrumbBase = "Yetenekler";
            ViewBag.Link = "/Skill/Index";
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var skillValue = skillManager.TGetById(id);
            skillManager.TDelete(skillValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            ViewBag.Breadcrumb = "Yetenek Düzenle";
            ViewBag.BreadcrumbBase = "Yetenekler";
            ViewBag.Link = "/Skill/Index";
            var skillValue = skillManager.TGetById(id);
            return View(skillValue);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {

            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
