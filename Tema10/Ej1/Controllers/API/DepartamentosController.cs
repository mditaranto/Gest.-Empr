﻿using Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ej1.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        // GET: api/<DepartamentosController>
        [HttpGet]
        public List<ClsDepartamentos> Get()
        {
            return DAL.ListadoDept.ListadoCompletoDept();
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public void Post([FromBody] ClsDepartamentos departamento)
        {
            DAL.ListadoDept.crearDept(departamento);
        }

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ClsDepartamentos departamento)
        {
            departamento.Id = id;
            DAL.ListadoDept.EditarDept(departamento);
        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DAL.ListadoDept.BorrarDept(id);
        }
    }
}
