using Mandalorian.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mandalorian.Controllers
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
            List<Misiones> listaMisiones = new List<Misiones>();
            return View();
        }
        [HttpPost]
        public IActionResult Detalles(Misiones mision)
        {
            return View(mision);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}