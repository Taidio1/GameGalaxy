using Microsoft.AspNetCore.Mvc;

namespace GameGalaxy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Games");
        }
    }
}