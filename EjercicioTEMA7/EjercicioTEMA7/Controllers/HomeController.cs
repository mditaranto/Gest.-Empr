using EjercicioTEMA7.Models;
using EjercicioTEMA7.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace EjercicioTEMA7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           DateTime fechaActual = DateTime.Now;
            int hora = fechaActual.Hour;

            String saludo;
            if (hora > 8 && hora < 12)
            {
                saludo = "Buenos días";
            }
            else if (hora > 12 && hora < 21)
            {
                saludo = "Buenas tardes";
            } 
            else
            {
                saludo = "Buenas noches";
            }
            ViewBag.fechaCompleta = fechaActual.ToLongDateString();
            ViewData["Saludo"] = saludo;

            Class persona = new Class()
            {
                Nombre = "Pablo",
                Edad = 20
            };

            return View(persona);
        }
    }
}