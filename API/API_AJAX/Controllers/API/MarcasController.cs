using DAL;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_AJAX.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        // GET: api/<MarcasController>
        [HttpGet]
        public List<clsMarcas> Get()
        {
            return clsMarcasManejadora.ListadoCompletoMarcas();
        }

    }
}
