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
    public class ActorController : ControllerBase
    {
        // GET: api/<ActorController>
        [HttpGet]
        [Route("lista")]
        public List<Actor>  Get()
        {
            return ActorData.Listar();
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public List<Actor> Get(int Id, Actor oActor)
        {
            return ActorData.Obtener(oActor);
        }

        // POST api/<ActorController>
        [HttpPost]
        [Authorize]
        [Route("add")]
        public bool Post([FromBody] Actor oActor)
        {
            return ActorData.Registrar(oActor);
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        [Authorize]
        public bool Put(int id, [FromBody] Actor oActor)
        {
            return ActorData.Modificar(oActor);
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public bool Delete(int id, [FromBody] Actor oActor)
        {
            return ActorData.Eliminar(oActor);
        }
    }
}
