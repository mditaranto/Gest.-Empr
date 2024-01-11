using Entidades;
using Examen.Models;
using Examen.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

namespace Examen.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Se introduce el viewModel sin parametros, al seleccionar una marca en la lista devolvera su id
        /// </summary>
        /// <returns></returns>
        public ActionResult SeleccionarCoche()
        {
            ListadoMarcasConListadoCoches viewModel = new ListadoMarcasConListadoCoches();
            return View(viewModel);
        }

        /// <summary>
        /// Con el id de la marca se buscan los coches de la misma y se muestran, con un action link a otra vista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SeleccionarCoche(ListadoMarcasConListadoCoches id)
        {
            ListadoMarcasConListadoCoches viewModel = new ListadoMarcasConListadoCoches(id.IdMarca);
            return View(viewModel);
        }

        public ActionResult EditarPrecio(int id) 
        {
            CocheConMarca viewModel = new CocheConMarca(id);
            return View(viewModel);
        }

        /// <summary>
        /// Deberia comprobar si el precio introducido es mayor que el anterior
        /// </summary>
        /// <param name="precio"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditarPrecio(string precio) 
        {
            return View(precio);
        }
    }
}