using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UD7Ejercicios.Models.DAL;
using UD7Ejercicios.Models.Entities;
using UD7Ejercicios.Models.ViewModel;

namespace UD7Ejercicios.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            clsPersona per = new clsPersona();
            DateTime fechaHoraActual = DateTime.Now;

            ViewBag.HoraActual = fechaHoraActual.ToLongTimeString();

            if (fechaHoraActual.Hour >= 7 && fechaHoraActual.Hour < 12)
            {
                ViewData["Saludo"] = "Buenos días";
            }
            else if (fechaHoraActual.Hour >= 12 && fechaHoraActual.Hour < 9)
            {
                ViewData["Saludo"] = "Buenas tardes";
            }
            else
            {
                ViewData["Saludo"] = "Buenas noches";
            }

            per.Nombre = "Yeray";
            per.Apellido = "Jiménez Cabello";

            return View(per);
        }

        public IActionResult EditarPersona()
        {
            clsEditarVM objetoEditarVM = new clsEditarVM();

            return View(objetoEditarVM);
        }

        [HttpPost]
        public IActionResult GuardarPersona(clsPersona persona)
        {
            return View();
        }

        public ActionResult listadoPersonas() {
            try { 

            return View(ListaPersonas.listadoCompletoPersonas());
            }catch (Exception)
            {
                return View("Error");
            }
        }

    }
}