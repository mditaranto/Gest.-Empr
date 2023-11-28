using Mandalorian.DAL;
using Mandalorian.Models;
using Mandalorian.Models.ViewModel;
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
            ListaMisionesConMision listaMisiones = new ListaMisionesConMision();
            return View(listaMisiones);
        }

        /// <summary>
        /// Recoge el id de la mision seleccionada y devuelve la vista Index con la mision elegida
        /// </summary>
        /// <param name="mision"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(Misiones mision)
        {
            ListaMisionesConMision listaMisiones = new ListaMisionesConMision();
            listaMisiones.MisionElegida = listaMisiones.ListaDeMisiones.Find(x => x.Id == mision.Id);
            return View(listaMisiones);
        }

    }
}