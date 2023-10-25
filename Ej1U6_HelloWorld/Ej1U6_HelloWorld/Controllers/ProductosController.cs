using Microsoft.AspNetCore.Mvc;

namespace Ej1U6_HelloWorld.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult ListadoProductos()
        {
            return View();
        }
    }
}
