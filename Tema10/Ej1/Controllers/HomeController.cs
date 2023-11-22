using Ej1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Ej1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            
            return View();
        }

    }
}