using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Emit;
using U6HoraActual.Models;

namespace U6HoraActual.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
             
            return View();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }


    }
}