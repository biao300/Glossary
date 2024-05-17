using Microsoft.AspNetCore.Mvc;

namespace Glossary.Controllers.View
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Term and Definition List";
            return View();
        }

        public IActionResult Edit()
        {
            ViewBag.Title = "Edit Term and Definition";
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Add Term and Definition";
            return View();
        }
    }
}
