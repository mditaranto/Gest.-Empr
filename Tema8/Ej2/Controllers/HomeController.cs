using Ej2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tema9.Models;

namespace Ej2.Controllers
{
    public class HomeController : Controller
    {
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
        public IActionResult Editar(ClsPersona persona)
        {
            IActionResult action;
            if (ModelState.IsValid)
            {
                action = RedirectToAction("GuardarPersona", persona);
            }
            else
            {
                action = View(persona);
            }
            return action;
        }

        [HttpPost]
        public IActionResult GuardarPersona(ClsPersona persona)
        {
            return View(persona);
        }

    }
}