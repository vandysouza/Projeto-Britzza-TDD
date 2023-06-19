using Microsoft.AspNetCore.Mvc;

namespace Britzza___v6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard(string username)
        {
            ViewBag.Username = username;
            return View();
        }

        public ActionResult Cliente()
        {
            return View();
        }

        public ActionResult Pedidos()
        {
            return View();
        }
    }
}
