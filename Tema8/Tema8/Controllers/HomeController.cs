using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tema8.Models;

namespace Tema8.Controllers
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

        public IActionResult Editar()
        {
            ClsPersona persona = new ClsPersona("Matias", "Apellidos", 1, 1); 
            return View(persona);
        }

        [HttpPost]
        public IActionResult GuardarPersona(ClsPersona persona)
        {
            return View(persona);
        }

    }
}