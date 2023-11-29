using Ej1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using DAL;
using Entidades;
using DAL.Manejadoras;
using BL;

namespace Ej1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            Conexion connection = new Conexion();
            SqlConnection conexionConBDD = connection.getConnection();
            ViewBag.Connection = "No se ha intentado conectar a la base de datos";

            try
            {
                ViewBag.Connection = $"Conectado: {conexionConBDD.State}";
            } catch (Exception e)
            {
                ViewBag.Connection = $"Error: {e.Message}";
            } finally
            {
                conexionConBDD.Close();
            }

            return View();
        }

        public IActionResult Listado()
        {
            try
            {
                return View(ListadoPersonasBl.ListadoCompletoPersonasBL());
            } catch(Exception e)
            {
                return View("Error");
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {

              return View(ListaPersonas.FindByID(id));
            } catch (Exception e)
            {
                return View("Error");
            }
        }
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int numeroFilasAfectadas =
                HandlerPersonaBL.BorrarPersonaBL(id);
                if (numeroFilasAfectadas == 0)
                {
                    ViewBag.Info = "No existe esa persona";
                }
                else if (numeroFilasAfectadas == -1)
                {
                    ViewBag.Info = "Los martes no esta permitido borrar personas";
                }
                else
                {
                    ViewBag.Info = "Persona borrada correctamente";
                    return RedirectToAction("Listado");
                }

                return View(ListaPersonas.FindByID(id));
            } catch (Exception e)
            {
                return View("Error");
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
              return View(ListaPersonas.FindByID(id));
            } catch (Exception e)
            {
                return View("Error");
            }   
        }

        [HttpPost]
        public IActionResult Edit(ClsPersona persona)
        {
            try
            {
                EditarPersona.Editar(persona);
                return RedirectToAction("Listado");
            } catch (Exception e)
            {
                return View("Error");
            }
        }
       

    }
}