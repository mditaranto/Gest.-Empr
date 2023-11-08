using Ejercicio1.Models;
using Ejercicio1.Models.DAL;
using Ejercicio1.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            clsPersona persona = new clsPersona();
            DateTime fechaActual = DateTime.Now;

            if (fechaActual.Hour >= 5 && fechaActual.Hour <= 12)
            {
                ViewData["Saludo"] = "Buenos días";

            }
            else if (fechaActual.Hour > 12 && fechaActual.Hour < 9)
            {
                ViewData["Saludo"] = "Buenas tardes";

            }
            else 
            {
                ViewData["Saludo"] = "Buenas noches";
            }

            ViewBag.HoraActual = fechaActual;


            persona.Nombre = "Juanma";
            persona.Apellido = "Sanchez";
            persona.Direccion = "¿Quieres raptarme?";

            ViewBag.Nombre=persona.Nombre;
            ViewBag.Apellido = persona.Apellido;
            ViewBag.Direccion = persona.Direccion;


            return View(persona);
        }

        public ActionResult listadoPersonas()
        {
            try 
            { 
                return View(ListadoPersona.listadoCompletoPersonas()); 

            } catch (Exception ex) 
            {
                //Mandar a otra vista de error 

                return View("Error");

            }
        
            
        }

    }
}