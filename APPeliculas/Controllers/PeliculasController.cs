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
    public class PeliculasController : ControllerBase
    {
        // GET: api/<PeliculasController>
        [HttpGet]
        [Authorize]
        public List<Peliculas> Get()
        {
            return PeliculaData.Listar();
        }

        // GET api/<PeliculasController>/5
        [HttpGet("{id}")]
        [Authorize]
        public List<Peliculas> Get(int Id, Peliculas oPeliculas)
        {
            return PeliculaData.Obtener(oPeliculas);
        }

        // POST api/<PeliculasController>
        [HttpPost]
        [Authorize]
        public bool Post([FromBody] Peliculas oPeliculas)
        {
            return PeliculaData.Registrar(oPeliculas);
        }

        // PUT api/<PeliculasController>/5
        [HttpPut("{id}")]
        [Authorize]
        public bool Put(int id, [FromBody] Peliculas oPeliculas)
        {
            return PeliculaData.Modificar(oPeliculas);
        }

        // DELETE api/<PeliculasController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public bool Delete(int id, [FromBody] Peliculas oPeliculas)
        {
            return PeliculaData.Eliminar(oPeliculas);
        }
    }
}
