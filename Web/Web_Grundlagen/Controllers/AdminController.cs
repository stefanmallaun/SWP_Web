using Microsoft.AspNetCore.Mvc;

namespace Web_Grundlagen.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
