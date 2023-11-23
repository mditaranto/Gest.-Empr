using Ej1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using DAL;

namespace Ej1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            SqlConnection connection = new SqlConnection();
            ViewBag.Connection = "No sa he intentado conectar a la base de datos";

            try
            {
                connection.ConnectionString = "Server=107-08\\SQLEXPRESS;Database=Persona;uid=prueba;pwd=123;trustServerCertificate=true";
                connection.Open();
                ViewBag.Connection = $"Conectado: {connection.State}";
            } catch (Exception e)
            {
                ViewBag.Connection = $"Error: {e.Message}";
            } finally
            {
                connection.Close();
            }

            return View();
        }

        public IActionResult Listado()
        {
            try
            {
                return View(ListaPersonas.ListadoCompletoPersonas());
            } catch(Exception e)
            {
                return View("Error");
            }

        }
       

    }
}