using Microsoft.AspNetCore.Mvc;

namespace Web_Grundlagen.Controllers {
    public class UserController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }
    }
}
