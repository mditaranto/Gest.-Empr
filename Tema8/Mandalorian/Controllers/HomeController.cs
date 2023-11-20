using Mandalorian.DAL;
using Mandalorian.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mandalorian.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Devuelve la vista index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// Recoge el id de la mision seleccionada y devuelve la vista detalles con la mision elegida
        /// </summary>
        /// <param name="mision"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Detalles(Misiones mision)
        {
            Misiones misionElegida = ListaMisiones.getListaMisiones().Find(x => x.Id == mision.Id);
            return View(misionElegida);
        }

    }
}