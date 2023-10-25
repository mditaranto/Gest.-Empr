using Microsoft.AspNetCore.Mvc;

namespace Ej1U6_HelloWorld.Controllers
{
    public class FirstController : Controller
    {
        public String Index()
        {
            return "Hello pablo";
        }

        public String Apellidos()
        {
            return "Chiwaka";
        }

        public IActionResult Saludo()
        {
            return View();
        }
    }
}
