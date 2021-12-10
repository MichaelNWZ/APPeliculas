using APPeliculas.Data;
using APPeliculas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepartoController : ControllerBase
    {
        // GET: api/<RepartoController>
        [HttpGet]
        [Authorize]
        public List<NombresReparto> Get()
        {
            return RepatoData.Listar();
        }

        // GET api/<RepartoController>/5
        [HttpGet("{id}")]
        [Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RepartoController>
        [HttpPost]
        [Authorize]
        public bool Post([FromBody] Reparto oReparto)
        {
            return RepatoData.Registrar(oReparto);
        }

        // PUT api/<RepartoController>/5
        [HttpPut("{id}")]
        [Authorize]
        public bool Put(int id, [FromBody] Reparto oReparto)
        {
            return RepatoData.Modificar(oReparto);
        }

        // DELETE api/<RepartoController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public bool Delete(int id, [FromBody] Reparto oReparto)
        {
            return RepatoData.Eliminar(oReparto);
        }
    }
}
