using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading;

namespace Web_Grundlagen.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            ViewBag.SelectedCulture = culture;
            return Ok();
        }
    }
}
