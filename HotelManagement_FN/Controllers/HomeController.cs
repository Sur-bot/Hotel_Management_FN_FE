using HotelManagement_FN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelManagement_FN.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Room()
        {
            return View();//mac dinh tra ve views/Home/Room.cshtml
        }

        public ActionResult Offers()
        {
            return View();//mac dinh tra ve views/Home/Offers.cshtml
        }

    }
}
