using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        readonly PortfolioManager portfolioManager = new(new EfPortfolioDal());
        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();
            BreadCrumb("Portföy", "Portföy");
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            BreadCrumb("Portföy Ekle", "Portföy");
            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolio porfolio)
        {
            BreadCrumb("Portföy Ekle", "Portföy");
            PortfolioValidator portfolioValidator = new();
            ValidationResult results = portfolioValidator.Validate(porfolio);

            if (results.IsValid)
            {
                portfolioManager.TAdd(porfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
                return View();
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = portfolioManager.TGetById(id);
            portfolioManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            BreadCrumb("Portföy Düzenle", "Portföy");
            var value = portfolioManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            BreadCrumb("Portföy Düzenle", "Portföy");
            PortfolioValidator portfolioValidator = new();
            ValidationResult results = portfolioValidator.Validate(portfolio);
            if (results.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(portfolio);
        }

        private void BreadCrumb(string breadCrumb, string breadCrumbBase)
        {
            ViewBag.Breadcrumb = breadCrumb;
            ViewBag.BreadcrumbBase = breadCrumbBase;
            ViewBag.Link = "/Portfolio/Index";
        }
    }
}
