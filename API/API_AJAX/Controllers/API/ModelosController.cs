using DAL;
using Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_AJAX.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        // GET: api/<ModelosController>
        [HttpGet]
        public List<clsModelos> Get()
        {
            return clsModelosManejadora.ListadoCompletoModelos();
        }

        // PUT api/<ModelosController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] clsModelos modelo)
        {
            modelo.Id = id;
            return clsModelosManejadora.EditarModelo(modelo);
        }
    }
}
